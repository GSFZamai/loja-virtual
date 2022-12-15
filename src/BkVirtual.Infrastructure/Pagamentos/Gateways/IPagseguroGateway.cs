using BkVirtual.Core.Integration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BkVirtual.Infrastructure.Pagamentos.Gateways
{
    public interface IPagseguroGateway
    {
        Task<PagSeguroGatewayResponse> EfetivarTransacao(RealizarPagamentoRequest request);
    }
}
