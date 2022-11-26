using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BkVirtual.Application.Handlers.PedidoHandler.FinalizarPedido
{
    public class FinalizarPedidoRequestValidator : AbstractValidator<FinalizarPedidoRequest>
    {
        public FinalizarPedidoRequestValidator()
        {
            RuleFor(x => x.UsuarioId)
                .NotEqual(Guid.Empty)
                .WithMessage("Usuário inválido");
        }
    }
}
