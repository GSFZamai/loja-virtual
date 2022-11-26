using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BkVirtual.Core.Integration
{
    public class PedidoIniciadoEvent : INotification
    {
        public Guid PedidoId { get; set; }
        public Guid UsuarioId { get; set; }
        public decimal Total { get; set; }
        public string NumeroCartao { get; set; }
        public string NomeCartao { get; set; }
        public string ExpiracaoCartao { get; set; }
        public string CodigoVerificadorCartao { get; set; }
        public IEnumerable<Item> Itens { get; set; }
    }

    public class Item
    {
        public Guid ProdutoId { get; set; }
        public int Quantidade { get; set; }
    }
}
