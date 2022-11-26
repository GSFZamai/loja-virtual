using AutoMapper;
using BkVirtual.Application.Handlers.PedidoHandler.AdicionarItemPedido;
using BkVirtual.Application.Handlers.PedidoHandler.FinalizarPedido;
using BkVirtual.Core.DTOs;
using BkVirtual.Core.Integration;
using BkVirtual.Core.NotificationError;
using BkVirtual.Domain.Entities;
using BkVirtual.Domain.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BkVirtual.Application.Handlers.PedidoHandler
{
    public class PedidoHandler :
        BaseHandler,
        IRequestHandler<AdicionarItemPedidoRequest, BaseResponse>,
        IRequestHandler<FinalizarPedidoRequest, BaseResponse>,
        IRequestHandler<CancelarPedidoRequest, BaseResponse>
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IProdutoRepository _produtoRepository;

        public PedidoHandler(IMediator mediator, IMapper mapper, IPedidoRepository pedidoRepository, IProdutoRepository produtoRepository) : base(mediator, mapper)
        {
            _pedidoRepository = pedidoRepository;
            _produtoRepository = produtoRepository;
        }

        public async Task<BaseResponse> Handle(AdicionarItemPedidoRequest request, CancellationToken cancellationToken)
        {
            if(await ValidarAsync(request, new AdicionarItemPedidoRequestValidator()) is var resultado && !resultado)
                return BaseResponse.Erro();

            var produto = await _produtoRepository.BuscarPorIdAsync(request.ProdutoId);

            if(produto is null)
            {
                await Mediator.Publish(new NotificacaoErro($"{nameof(AdicionarItemPedidoRequest)}", "Produto não encontrado"));
            }

            var itemPedido = new PedidoItem(request.ProdutoId, request.Quantidade, produto.Valor, produto.Nome);
            var pedidoIniciado = await _pedidoRepository.BuscarPedidoCarrinhoPorIdUsuarioAsync(request.UsuarioId);

            if(pedidoIniciado is null)
            {
                var pedido = new Pedido(request.UsuarioId);
                pedido.AdicionarItemNoPedido(itemPedido);
                await _pedidoRepository.AdicionarAsync(pedido);
            }else
            {
                var itemExistente = pedidoIniciado.ExistePedidoItem(itemPedido.ProdutoId);
                pedidoIniciado.AdicionarItemNoPedido(itemPedido);
                if (itemExistente is false)
                {
                    await _pedidoRepository.AdicionarItemAsync(itemPedido);
                }
            }

            await _pedidoRepository.UnityOfWork.SalvarAlteracoesAsync();

            return BaseResponse.Sucesso();
        }

        public async Task<BaseResponse> Handle(FinalizarPedidoRequest request, CancellationToken cancellationToken)
        {
            if (await ValidarAsync(request, new FinalizarPedidoRequestValidator()) is var resultado && !resultado)
                return BaseResponse.Erro();

            var pedidoCarrinho = await _pedidoRepository.BuscarPedidoCarrinhoPorIdUsuarioAsync(request.UsuarioId);

            if(pedidoCarrinho is null)
            {
                await Mediator.Publish(new NotificacaoErro($"{nameof(FinalizarPedidoRequest)}", "Carrinho de compras inválido."));
                return BaseResponse.Erro();
            }

            pedidoCarrinho.IniciarPedido();
            await _pedidoRepository.UnityOfWork.SalvarAlteracoesAsync();

            await Mediator.Publish(new PedidoIniciadoEvent
            {
                Total = pedidoCarrinho.ValorTotal,
                ExpiracaoCartao = request.ExpiracaoCartao,
                NomeCartao = request.NomeCartao,
                NumeroCartao = request.NumeroCartao,
                CodigoVerificadorCartao = request.CodigoVerificadorCartao,
                UsuarioId = request.UsuarioId,
                PedidoId = pedidoCarrinho.Id,
                Itens = pedidoCarrinho.PedidoItens.Select(x => new Item()
                {
                    ProdutoId = x.ProdutoId,
                    Quantidade = x.Quantidade
                })
            });

            return BaseResponse.Sucesso();
        }

        public async Task<BaseResponse> Handle(CancelarPedidoRequest request, CancellationToken cancellationToken)
        {
            var pedido = await _pedidoRepository.BuscarPorIdAsync(request.PedidoId);

            if(pedido is null)
            {
                await Mediator.Publish(new NotificacaoErro($"{nameof(CancelarPedidoRequest)}", "Pedido não encontrado."));
                return BaseResponse.Erro();
            }

            pedido.RetornarPedidoCarrinho();
            await _pedidoRepository.UnityOfWork.SalvarAlteracoesAsync();
            return BaseResponse.Sucesso();
        }
    }
}
