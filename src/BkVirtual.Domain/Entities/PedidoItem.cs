using BkVirtual.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BkVirtual.Domain.Entities
{
    public class PedidoItem : Entity
    {
       
        public Guid PedidoId { get; private set; }
        public Guid ProdutoId { get; private set; }
        public int Quantidade { get; private set; }
        public decimal ValorUnitario { get; private set; }
        public string NomeProduto { get; private set; }

        public PedidoItem(Guid produtoId, int quantidade, decimal valorUnitario, string nomeProduto)
        {
            ProdutoId = produtoId;
            Quantidade = quantidade;
            ValorUnitario = valorUnitario;
            NomeProduto = nomeProduto;
        }

        public void VincularPedido(Guid pedidoId)
        {
            PedidoId = pedidoId;
        }

        public decimal CalcularValor()
        {
            return Quantidade * ValorUnitario;
        }

        public void AdicionarQuantidade(int quantidade)
        {
            Quantidade += quantidade;
        }

        //EF relation
        public Pedido Pedido { get; private set; }
        public override void Validar()
        {
            if (ProdutoId == Guid.Empty)
                throw new DomainException("Id do produto inválido.");

            if (Quantidade <= 0)
                throw new DomainException("Quantidade deve ser maior que 0");

            if (ValorUnitario <= 0)
                throw new DomainException("Valor deve ser maior que 0");

            if (string.IsNullOrWhiteSpace(NomeProduto))
                throw new DomainException("Nome do produto inválido.");
        }
    }
}
