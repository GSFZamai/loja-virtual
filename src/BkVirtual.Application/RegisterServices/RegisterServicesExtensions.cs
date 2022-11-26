using BkVirtual.Application.Handlers.CategoriaHandler;
using BkVirtual.Application.Handlers.CategoriaHandler.Cadastrar;
using BkVirtual.Application.Handlers.CategoriaHandler.Editar;
using BkVirtual.Application.Handlers.CategoriaHandler.Listar;
using BkVirtual.Application.Handlers.CategoriaHandler.ListarPorId;
using BkVirtual.Application.Handlers.PedidoHandler;
using BkVirtual.Application.Handlers.PedidoHandler.AdicionarItemPedido;
using BkVirtual.Application.Handlers.PedidoHandler.FinalizarPedido;
using BkVirtual.Application.Handlers.ProdutoHandler;
using BkVirtual.Application.Handlers.ProdutoHandler.Cadastrar;
using BkVirtual.Application.Handlers.ProdutoHandler.Editar;
using BkVirtual.Application.Handlers.ProdutoHandler.Listar;
using BkVirtual.Application.Handlers.ProdutoHandler.ListarPorId;
using BkVirtual.Application.Mappings;
using BkVirtual.Core.DTOs;
using BkVirtual.Core.Integration;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace BkVirtual.Application.RegisterServices;

public static class RegisterServicesExtensions
{
    public static IServiceCollection RegistrarServicesApplication(this IServiceCollection services)
    {
        services.AddTransient<IRequestHandler<CadastrarCategoriaRequest, BaseResponse>, CategoriaHandler>();
        services.AddTransient<IRequestHandler<ListarCategoriaRequest, BaseResponse>, CategoriaHandler>();
        services.AddTransient<IRequestHandler<ListarCategoriaPorIdRequest, BaseResponse>, CategoriaHandler>();
        services.AddTransient<IRequestHandler<EditarCategoriaRequest, BaseResponse>, CategoriaHandler>();
        
        services.AddTransient<IRequestHandler<CadastrarProdutoRequest, BaseResponse>, ProdutoHandler>();
        services.AddTransient<IRequestHandler<ListarProdutoRequest, BaseResponse>, ProdutoHandler>();
        services.AddTransient<IRequestHandler<ListarProdutoPorIdRequest, BaseResponse>, ProdutoHandler>();
        services.AddTransient<IRequestHandler<EditarProdutoRequest, BaseResponse>, ProdutoHandler>();

        services.AddTransient<IRequestHandler<AdicionarItemPedidoRequest, BaseResponse>, PedidoHandler>();
        services.AddTransient<IRequestHandler<CancelarPedidoRequest, BaseResponse>, PedidoHandler>();
        services.AddTransient<IRequestHandler<FinalizarPedidoRequest, BaseResponse>, PedidoHandler>();
        services.AddTransient<IRequestHandler<MovimentarEstoqueRequest, bool>, ProdutoHandler>();


        services.AddAutoMapper(typeof(CategoriaProfile));
        return services;
    }
}