using BkVirtual.Core.Domain;
using BkVirtual.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BkVirtual.Domain.Entities
{
    public class Pedido : Entity
    {
        public Guid UsuarioId { get; private set; }
        public decimal ValorTotal { get; private set; }
        public StatusPedido Status { get; private set; }

        private List<PedidoItem> _pedidoItems;
        public IEnumerable<PedidoItem> PedidoItens => _pedidoItems;

        public Pedido(Guid usuarioId)
        {
            UsuarioId = usuarioId;
            Status = StatusPedido.Carrinho;
            _pedidoItems = new List<PedidoItem>();
        }

        public void CalcularValorTotal()
        {
            ValorTotal = _pedidoItems.Sum(item => item.CalcularValor());
        }

        public void IniciarPedido() => Status = StatusPedido.Iniciado;
        public void RetornarPedidoCarrinho() => Status = StatusPedido.Carrinho;

        public void AdicionarItemNoPedido(PedidoItem item)
        {
            item.VincularPedido(Id);

            if(ExistePedidoItem(item) is var itemEncontrado && itemEncontrado is not null)
            {
                itemEncontrado.AdicionarQuantidade(item.Quantidade);
                item = itemEncontrado;
            }else
            {
                _pedidoItems.Add(item);
            }

            CalcularValorTotal();
        }

        private PedidoItem? ExistePedidoItem(PedidoItem item)
        {
            return _pedidoItems.FirstOrDefault(x => x.ProdutoId == item.ProdutoId);
        }

        public bool ExistePedidoItem(Guid produtoId)
        {
            return _pedidoItems.Any(x => x.ProdutoId == produtoId);
        }

        public override void Validar()
        {
            throw new NotImplementedException();
        }
    }
}
