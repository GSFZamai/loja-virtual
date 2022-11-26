using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BkVirtual.Application.Handlers.PedidoHandler.BuscarCarrinho
{
    public class PedidoResponse
    {
        public Guid Id { get; set; }
        public string Status { get; set; }
        public decimal ValorTotal { get; set; }
        public IEnumerable<PedidoItemResponse> PedidoItens { get; set; }

    }

    public class PedidoItemResponse
    {
        public Guid ProdutoId { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorUnitario { get; set; }
        public string NomeProduto { get; set; }
    }
}
