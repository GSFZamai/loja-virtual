using BkVirtual.Core.Data;
using BkVirtual.Domain.Entities;
using BkVirtual.Domain.Interfaces.Repositories;
using BkVirtual.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace BkVirtual.Infrastructure.Repositories;

public class CategoriaRepository : ICategoriaRepository
{
    private readonly ApplicationDbContext _context;
    public IUnityOfWork UnityOfWork => _context;

    public CategoriaRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task AdicionarAsync(Categoria categoria)
    {
        await _context.Categorias.AddAsync(categoria);
    }

    public async Task<Categoria?> BuscarPorIdAsync(Guid id)
    {
        return await _context.Categorias.FirstOrDefaultAsync(c => c.Id == id);
    }

    public IQueryable<Categoria> BuscarTodas()
    {
        return _context.Categorias.Where(c => c.Ativo).OrderByDescending(c => c.Cadastro);
    }
}