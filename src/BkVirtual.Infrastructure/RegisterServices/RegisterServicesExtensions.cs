using BkVirtual.Core.DTOs;
using BkVirtual.Domain.Interfaces.Repositories;
using BkVirtual.Infrastructure.Context;
using BkVirtual.Infrastructure.DTOs;
using BkVirtual.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BkVirtual.Infrastructure.RegisterServices;

public static class RegisterServicesExtensions
{
    public static IServiceCollection RegistrarServicosInfrasctructure(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("LojaVirtualConnection"),
                db => db.MigrationsHistoryTable("Historico_Migracoes_EF")));

        services.AddScoped<ICategoriaRepository, CategoriaRepository>();
        services.AddScoped<IProdutoRepository, ProdutoRepository>();
        services.AddScoped<IPedidoRepository, PedidoRepository>();
        services.AddScoped(typeof(IPaginacao<>), typeof(Paginacao<>));
        return services;
    }
}