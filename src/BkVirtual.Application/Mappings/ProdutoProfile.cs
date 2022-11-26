using AutoMapper;
using BkVirtual.Application.Handlers.ProdutoHandler.Cadastrar;
using BkVirtual.Application.Handlers.ProdutoHandler.Editar;
using BkVirtual.Application.Handlers.ProdutoHandler.Listar;
using BkVirtual.Application.Handlers.ProdutoHandler.ListarPorId;
using BkVirtual.Domain.Entities;

namespace BkVirtual.Application.Mappings;

public class ProdutoProfile : Profile
{
    public ProdutoProfile()
    {
        CreateMap<CadastrarProdutoRequest, Produto>()
            .ConstructUsing(x => new Produto(x.Nome, x.Descricao, x.Valor, x.QuantidadeEstoque, x.CategoriaId));

        CreateMap<Produto, ListarProdutoResponse>();
        CreateMap<Produto, ListarProdutoPorIdResponse>();
        CreateMap<Produto, EditarProdutoResponse>();
        CreateMap<Categoria, ListarProdutoPorIdCategoriaResponse>();
    }
}