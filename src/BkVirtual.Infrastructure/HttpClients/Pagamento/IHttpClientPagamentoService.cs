using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BkVirtual.Infrastructure.HttpClients.Pagamento
{
    public interface IHttpClientPagamentoService
    {
        Task<TResponse> PostAsync<TResponse, TRequest>(TRequest request)
            where TResponse : class where TRequest : class;
    }
}
