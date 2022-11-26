using BkVirtual.Core.Data;
using BkVirtual.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BkVirtual.Domain.Interfaces.Repositories
{
    public interface IPedidoRepository
    {
        IUnityOfWork UnityOfWork { get; }
        Task<Pedido?> BuscarPedidoCarrinhoPorIdUsuarioAsync(Guid usuarioId);
        Task AdicionarAsync(Pedido pedido);
        Task<Pedido?> BuscarPorIdAsync(Guid id);
        Task AdicionarItemAsync(PedidoItem pedidoItem);
    }
}
