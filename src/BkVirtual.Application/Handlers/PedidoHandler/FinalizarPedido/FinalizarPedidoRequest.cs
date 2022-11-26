using BkVirtual.Core.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BkVirtual.Application.Handlers.PedidoHandler.FinalizarPedido
{
    public class FinalizarPedidoRequest : IRequest<BaseResponse>
    {
        [JsonIgnore]
        public Guid UsuarioId { get; set; }
        public string NumeroCartao { get; set; }
        public string NomeCartao { get; set; }
        public string ExpiracaoCartao { get; set; }
        public string CodigoVerificadorCartao { get; set; }


    }
}
