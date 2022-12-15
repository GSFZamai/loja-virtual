using BkVirtual.Core.Domain;
using BkVirtual.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BkVirtual.Domain.Entities
{
    public class Transacao : Entity
    {
       

        public Guid PedidoId { get; private set; }
        public decimal Total { get; private set; }
        public string PagamentoGatewayId { get; private set; }
        public StatusTransacao Status { get; private set; }

        // EF relation
        public Pedido Pedido { get; set; }

        public Transacao(Guid pedidoId, decimal total, string pagamentoGatewayId)
        {
            PagamentoGatewayId = pagamentoGatewayId;
            Total = total;
            PedidoId = pedidoId;
        }

        public void TransacaoPaga() => Status = StatusTransacao.Pago;
        public void TransacaoRecusada() => Status = StatusTransacao.Recusado;

        public override void Validar()
        {
            throw new NotImplementedException();
        }
    }
}
