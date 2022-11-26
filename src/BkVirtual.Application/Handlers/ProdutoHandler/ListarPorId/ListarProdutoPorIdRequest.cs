using BkVirtual.Core.DTOs;
using MediatR;

namespace BkVirtual.Application.Handlers.ProdutoHandler.ListarPorId;

public record ListarProdutoPorIdRequest(Guid Id) : IRequest<BaseResponse>;