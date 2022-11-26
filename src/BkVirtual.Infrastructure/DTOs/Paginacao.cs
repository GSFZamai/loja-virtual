using BkVirtual.Core.DTOs;
using Microsoft.EntityFrameworkCore;

namespace BkVirtual.Infrastructure.DTOs;

public class Paginacao<T> : List<T>, IPaginacao<T>
{
    public int TotalDeItens { get; }
    public int Indice { get; }
    public int TotalDePaginas { get; }

    public Paginacao()
    {
    }

    public Paginacao(List<T> itens, int totalDeItens, int indice, int tamanhoPagina)
    {
        Indice = indice;
        TotalDeItens = totalDeItens;
        TotalDePaginas = (int)Math.Ceiling(totalDeItens / (double)tamanhoPagina);
        AddRange(itens);
    }

    public async Task<IPaginacao<T>> CriarAsync(IQueryable<T> consulta, int indice, int tamanhoDaPagina)
    {
        var quantidadeDeItens = consulta.Count();
        var itens = await consulta.Skip((indice - 1) * tamanhoDaPagina).Take(tamanhoDaPagina).ToListAsync();
        return new Paginacao<T>(itens, quantidadeDeItens, indice, tamanhoDaPagina); 
    }
}