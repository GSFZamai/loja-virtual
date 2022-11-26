using BkVirtual.Core.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BkVirtual.Application.Handlers.PedidoHandler.AdicionarItemPedido
{
    public class AdicionarItemPedidoRequest : IRequest<BaseResponse>
    {
        [JsonIgnore]
        public Guid UsuarioId { get; set; }
        public Guid ProdutoId { get; set; }
        public int Quantidade { get; set; }
    }
}
