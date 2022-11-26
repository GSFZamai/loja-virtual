using BkVirtual.Core.Data;
using BkVirtual.Domain.Entities;
using BkVirtual.Domain.Enums;
using BkVirtual.Domain.Interfaces.Repositories;
using BkVirtual.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BkVirtual.Infrastructure.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly ApplicationDbContext _context;

        public PedidoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IUnityOfWork UnityOfWork => _context;

        public async Task AdicionarAsync(Pedido pedido)
        {
            await _context.Pedidos.AddAsync(pedido);
        }

        public async Task AdicionarItemAsync(PedidoItem pedidoItem)
        {
            await _context.PedidoItem.AddAsync(pedidoItem);
        }

        public async Task<Pedido?> BuscarPedidoCarrinhoPorIdUsuarioAsync(Guid usuarioId)
        {
            var pedido = await _context.Pedidos
                .FirstOrDefaultAsync(p => p.UsuarioId == usuarioId && p.Status == StatusPedido.Carrinho);

            if (pedido == null) return null;

            await _context.Entry(pedido).Collection(p => p.PedidoItens).LoadAsync();

            return pedido;
        }

        public async Task<Pedido?> BuscarPorIdAsync(Guid id)
        {
            return await _context.Pedidos.FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
