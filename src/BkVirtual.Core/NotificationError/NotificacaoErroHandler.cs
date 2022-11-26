using MediatR;

namespace BkVirtual.Core.NotificationError;

public class NotificacaoErroHandler : INotificationHandler<NotificacaoErro>
{
    private ICollection<NotificacaoErro> _erros { get; set; }

    public NotificacaoErroHandler()
    {
        _erros = new List<NotificacaoErro>();
    }

    public async Task Handle(NotificacaoErro notificaoErro, CancellationToken cancellationToken)
    {
        _erros.Add(notificaoErro);
        await Task.CompletedTask;
    }

    public IEnumerable<NotificacaoErro> ObterErros => _erros;
    public bool ExisteErros => _erros.Any();
}