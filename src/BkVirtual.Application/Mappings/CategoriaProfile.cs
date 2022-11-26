using AutoMapper;
using BkVirtual.Application.Handlers.CategoriaHandler.Cadastrar;
using BkVirtual.Application.Handlers.CategoriaHandler.Editar;
using BkVirtual.Application.Handlers.CategoriaHandler.Listar;
using BkVirtual.Application.Handlers.CategoriaHandler.ListarPorId;
using BkVirtual.Domain.Entities;

namespace BkVirtual.Application.Mappings;

public class CategoriaProfile : Profile
{
    public CategoriaProfile()
    {
        CreateMap<CadastrarCategoriaRequest, Categoria>()
            .ConstructUsing(request => new Categoria(request.Nome, request.Descricao));

        CreateMap<Categoria, ListarCategoriaResponse>();
        CreateMap<Categoria, ListarCategoriaPorIdResponse>();
        
        CreateMap<Categoria, EditarCategoriaResponse>();
    }
}