using BkVirtual.Core.Integration;
using BkVirtual.Core.NotificationError;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace BkVirtual.Core.RegisterServices;

public static class RegisterServicesExtensions
{
    public static IServiceCollection RegistrarServicosCore(this IServiceCollection services)
    {
        services.AddMediatR(typeof(NotificacaoErro).Assembly);
        services.AddScoped<INotificationHandler<NotificacaoErro>, NotificacaoErroHandler>();
        services.AddScoped<INotificationHandler<PedidoIniciadoEvent>, ApplicationEventsHandler>();

        return services;
    }
}