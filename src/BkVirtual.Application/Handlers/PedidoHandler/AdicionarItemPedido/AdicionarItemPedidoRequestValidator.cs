using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BkVirtual.Application.Handlers.PedidoHandler.AdicionarItemPedido
{
    public class AdicionarItemPedidoRequestValidator : AbstractValidator<AdicionarItemPedidoRequest>
    {
        public AdicionarItemPedidoRequestValidator()
        {
            RuleFor(x => x.Quantidade)
                .GreaterThan(0).WithMessage("Quantidade inválida");

         
        }
    }
}
