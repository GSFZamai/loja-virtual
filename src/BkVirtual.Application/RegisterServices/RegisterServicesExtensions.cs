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
using BkVirtual.Infrastructure.Pagamentos.Handlers;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace BkVirtual.Application.RegisterServices;

public static class RegisterServicesExtensions
{
    public static IServiceCollection RegistrarServicesApplication(this IServiceCollection services)
    {
        services.AddScoped<IRequestHandler<CadastrarCategoriaRequest, BaseResponse>, CategoriaHandler>();
        services.AddScoped<IRequestHandler<ListarCategoriaRequest, BaseResponse>, CategoriaHandler>();
        services.AddScoped<IRequestHandler<ListarCategoriaPorIdRequest, BaseResponse>, CategoriaHandler>();
        services.AddScoped<IRequestHandler<EditarCategoriaRequest, BaseResponse>, CategoriaHandler>();

        services.AddScoped<IRequestHandler<CadastrarProdutoRequest, BaseResponse>, ProdutoHandler>();
        services.AddScoped<IRequestHandler<ListarProdutoRequest, BaseResponse>, ProdutoHandler>();
        services.AddScoped<IRequestHandler<ListarProdutoPorIdRequest, BaseResponse>, ProdutoHandler>();
        services.AddScoped<IRequestHandler<EditarProdutoRequest, BaseResponse>, ProdutoHandler>();

        services.AddScoped<IRequestHandler<AdicionarItemPedidoRequest, BaseResponse>, PedidoHandler>();
        services.AddScoped<IRequestHandler<CancelarPedidoRequest, BaseResponse>, PedidoHandler>();
        services.AddScoped<IRequestHandler<FinalizarPedidoRequest, BaseResponse>, PedidoHandler>();
        services.AddScoped<IRequestHandler<MovimentarEstoqueRequest, bool>, ProdutoHandler>();
        services.AddScoped<IRequestHandler<RealizarPagamentoRequest, BaseResponse>, PagamentoHandler>();

        services.AddAutoMapper(typeof(CategoriaProfile));
        return services;
    }
}