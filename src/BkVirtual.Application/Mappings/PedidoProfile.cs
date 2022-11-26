using AutoMapper;
using BkVirtual.Application.Handlers.PedidoHandler.BuscarCarrinho;
using BkVirtual.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BkVirtual.Application.Mappings
{
    public class PedidoProfile : Profile
    {
        public PedidoProfile()
        {
            CreateMap<Pedido, PedidoResponse>();
            CreateMap<PedidoItem, PedidoItemResponse>();
        }
    }
}
