namespace BkVirtual.Core.DTOs;

public interface IPaginacao<T>
{
    int TotalDeItens { get; }
    int Indice { get; }
    int TotalDePaginas { get; }

    Task<IPaginacao<T>> CriarAsync(IQueryable<T> consulta, int indice, int tamanhoDaPagina);
}