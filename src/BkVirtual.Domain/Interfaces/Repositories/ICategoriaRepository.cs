using BkVirtual.Core.Data;
using BkVirtual.Domain.Entities;

namespace BkVirtual.Domain.Interfaces.Repositories;

public interface ICategoriaRepository
{
    IUnityOfWork UnityOfWork { get; }
    Task AdicionarAsync(Categoria categoria);
    Task<Categoria?> BuscarPorIdAsync(Guid id);
    IQueryable<Categoria> BuscarTodas();
}