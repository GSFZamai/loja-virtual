using BkVirtual.Core.NotificationError;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BkVirtual.WEB.Controllers;

[ApiController]
public abstract class MainController : ControllerBase
{
    protected readonly IMediator Mediator;
    protected readonly NotificacaoErroHandler NotificacaoErroHandler;

    protected MainController(IMediator mediator, INotificationHandler<NotificacaoErro> notificacaoErroHandler)
    {
        Mediator = mediator;
        NotificacaoErroHandler = (NotificacaoErroHandler)notificacaoErroHandler;
    }

    protected bool ProcessoInvalido() =>
        NotificacaoErroHandler.ExisteErros;

    protected IEnumerable<NotificacaoErro> ObterErros => NotificacaoErroHandler.ObterErros;
}