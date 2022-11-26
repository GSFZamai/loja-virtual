using BkVirtual.Core.DTOs;
using MediatR;

namespace BkVirtual.Application.Handlers.CategoriaHandler.ListarPorId;

public record ListarCategoriaPorIdRequest(Guid Id) : IRequest<BaseResponse>;