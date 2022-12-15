using AutoMapper;
using BkVirtual.Core.DTOs;
using BkVirtual.Core.Handlers;
using BkVirtual.Core.Integration;
using BkVirtual.Domain.Entities;
using BkVirtual.Domain.Interfaces.Repositories;
using BkVirtual.Infrastructure.Pagamentos.Gateways;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BkVirtual.Infrastructure.Pagamentos.Handlers
{
    public class PagamentoHandler : BaseHandler, IRequestHandler<RealizarPagamentoRequest, BaseResponse>
    {

        private readonly IPagseguroGateway _pagseguroGateway;
        private readonly ITransacaoRepository _transacaoRepository;

        public PagamentoHandler(IMediator mediator, IMapper mapper, IPagseguroGateway pagseguroGateway, ITransacaoRepository transacaoRepository) : base(mediator, mapper)
        {
            _pagseguroGateway = pagseguroGateway;
            _transacaoRepository = transacaoRepository;
        }

        public async Task<BaseResponse> Handle(RealizarPagamentoRequest request, CancellationToken cancellationToken)
        {
            var resultado = await _pagseguroGateway.EfetivarTransacao(request);
            var transacao = new Transacao(request.PedidoId, request.Total, resultado.Id);

            if (resultado.Status == "PAID")
            {
                //lançar evento passar pedido conclído.
                transacao.TransacaoPaga();
                //adiciona transação
                await _transacaoRepository.SalvarAsync(transacao);
                //salvar alteraçoes
                await _transacaoRepository.UnityOfWork.SalvarAlteracoesAsync();

                return BaseResponse.Sucesso();
            }
            else
            {
                transacao.TransacaoRecusada();
                await _transacaoRepository.SalvarAsync(transacao);
                //salvar alteraçoes
                await _transacaoRepository.UnityOfWork.SalvarAlteracoesAsync();
                return BaseResponse.Erro();
            }
        }
    }
}
