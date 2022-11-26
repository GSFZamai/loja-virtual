using BkVirtual.Core.Data;
using BkVirtual.Domain.Entities;

namespace BkVirtual.Domain.Interfaces.Repositories;

public interface IProdutoRepository
{
    IUnityOfWork UnityOfWork { get; }
    Task AdicionarAsync(Produto produto);
    Task<Produto?> BuscarPorIdAsync(Guid id);
    IQueryable<Produto> BuscarTodos();
}