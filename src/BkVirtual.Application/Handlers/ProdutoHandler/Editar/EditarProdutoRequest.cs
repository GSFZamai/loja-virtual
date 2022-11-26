using BkVirtual.Core.DTOs;
using MediatR;

namespace BkVirtual.Application.Handlers.ProdutoHandler.Editar;

public record EditarProdutoRequest(Guid Id, string Nome, string Descricao, bool Ativo,
    decimal Valor, Guid CategoriaId) : IRequest<BaseResponse>;