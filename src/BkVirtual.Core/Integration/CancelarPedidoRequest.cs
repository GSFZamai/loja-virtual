using BkVirtual.Core.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BkVirtual.Core.Integration
{
    public class CancelarPedidoRequest : IRequest<BaseResponse>
    {
        public Guid PedidoId { get; set; }  
    }
}
