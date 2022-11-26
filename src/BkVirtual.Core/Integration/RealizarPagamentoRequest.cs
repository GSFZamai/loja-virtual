using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BkVirtual.Core.Integration
{
    public class RealizarPagamentoRequest
    {
        public Guid PedidoId { get; set; }
        public Guid UsuarioId { get; set; }
        public decimal Total { get; set; }
        public string NumeroCartao { get; set; }
        public string NomeCartao { get; set; }
        public string ExpiracaoCartao { get; set; }
        public string CodigoVerificadorCartao { get; set; }
    }
}
