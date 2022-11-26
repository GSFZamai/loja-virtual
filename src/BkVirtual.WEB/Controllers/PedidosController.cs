using AutoMapper;
using BkVirtual.Application.Handlers.PedidoHandler.AdicionarItemPedido;
using BkVirtual.Application.Handlers.PedidoHandler.BuscarCarrinho;
using BkVirtual.Application.Handlers.PedidoHandler.FinalizarPedido;
using BkVirtual.Core.DTOs;
using BkVirtual.Core.NotificationError;
using BkVirtual.Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BkVirtual.WEB.Controllers
{
    [Route("[controller]")]
    public class PedidosController : MainController
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IMapper _mapper;

        public PedidosController(IMediator mediator, INotificationHandler<NotificacaoErro> notificacaoErroHandler, IPedidoRepository pedidoRepository, IMapper mapper) : base(mediator, notificacaoErroHandler)
        {
            _pedidoRepository = pedidoRepository;
            _mapper = mapper;
        }

        [HttpPost("/adicionar-item-carrinho")]
        public async Task<IActionResult> AdicionarItemCarrinhoAsync([FromBody] AdicionarItemPedidoRequest request)
        {
            request.UsuarioId = Guid.Parse("69E28159-589B-46BE-A2BF-6C70FCE5A810");

            var resultado = await Mediator.Send(request);

            if(ProcessoInvalido())
            {
                return BadRequest(BaseResponse.Erro(ObterErros));
            }

            return Ok(resultado);
        }

        [HttpGet("/carrinho")]
        public async Task<IActionResult> BuscarCarrinhoAsync()
        {
            var usuarioId = Guid.Parse("69E28159-589B-46BE-A2BF-6C70FCE5A810");

            var pedidoCarrinho = await _pedidoRepository.BuscarPedidoCarrinhoPorIdUsuarioAsync(usuarioId);

            if(pedidoCarrinho is null)
            {
                return NoContent();
            }

            return Ok(_mapper.Map<PedidoResponse>(pedidoCarrinho));
        }

        [HttpPost("/fechar-pedido")]
        public async Task<IActionResult> FecharPedidoAsync([FromBody] FinalizarPedidoRequest request)
        {
            request.UsuarioId = Guid.Parse("69E28159-589B-46BE-A2BF-6C70FCE5A810");

            var resultado = await Mediator.Send(request);

            if (ProcessoInvalido())
            {
                return BadRequest(ObterErros);
            }

            return Ok(resultado);
        }
    }
}
