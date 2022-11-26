using BkVirtual.Core.Data;
using BkVirtual.Domain.Entities;
using BkVirtual.Domain.Interfaces.Repositories;
using BkVirtual.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace BkVirtual.Infrastructure.Repositories;

public class ProdutoRepository : IProdutoRepository
{
    private readonly ApplicationDbContext _context;

    public ProdutoRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public IUnityOfWork UnityOfWork => _context;

    public async Task AdicionarAsync(Produto produto)
    {
        await _context.Produtos.AddAsync(produto);
    }
    
    public async Task<Produto?> BuscarPorIdAsync(Guid id)
    {
        return await _context.Produtos
            .Include(p => p.Categoria)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public IQueryable<Produto> BuscarTodos()
    {
        return _context.Produtos.Where(p => p.Ativo);
    }
}