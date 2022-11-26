using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BkVirtual.Core.Integration
{
    public class ApplicationEventsHandler : INotificationHandler<PedidoIniciadoEvent>
    {
        private readonly IMediator _mediator;

        public ApplicationEventsHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Handle(PedidoIniciadoEvent notification, CancellationToken cancellationToken)
        {
            var resultado = await _mediator.Send(new MovimentarEstoqueRequest() { Itens = notification.Itens}, cancellationToken);

            if (resultado)
            {
                await _mediator.Send(new RealizarPagamentoRequest
                {
                    UsuarioId = notification.UsuarioId,
                    CodigoVerificadorCartao = notification.CodigoVerificadorCartao,
                    ExpiracaoCartao = notification.ExpiracaoCartao,
                    PedidoId = notification.PedidoId,
                    Total = notification.Total,
                    NomeCartao = notification.NomeCartao,
                    NumeroCartao = notification.NumeroCartao
                }, cancellationToken);
            }else
            {
                await _mediator.Send(new CancelarPedidoRequest { PedidoId = notification.PedidoId }, cancellationToken);
            }
        
        }
    }
}
