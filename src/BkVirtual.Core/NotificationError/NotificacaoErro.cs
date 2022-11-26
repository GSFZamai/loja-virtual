using MediatR;

namespace BkVirtual.Core.NotificationError;

public class NotificacaoErro : INotification
{
    public string NomeDoProcesso { get; set; }
    public string Mensagem { get; set; }
    
    public NotificacaoErro(string nomeDoProcesso, string mensagem)
    {
        NomeDoProcesso = nomeDoProcesso;
        Mensagem = mensagem;
    }
}