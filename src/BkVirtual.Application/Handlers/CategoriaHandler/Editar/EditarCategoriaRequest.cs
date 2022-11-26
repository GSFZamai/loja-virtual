using BkVirtual.Core.DTOs;
using MediatR;

namespace BkVirtual.Application.Handlers.CategoriaHandler.Editar;

public record EditarCategoriaRequest(Guid Id, string Nome, string Descricao, bool Ativo) : IRequest<BaseResponse>;