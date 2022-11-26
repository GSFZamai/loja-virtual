using BkVirtual.Core.DTOs;
using MediatR;

namespace BkVirtual.Application.Handlers.ProdutoHandler.Cadastrar;

public record CadastrarProdutoRequest(
    string Nome,
    string Descricao,
    decimal Valor,
    int QuantidadeEstoque,
    Guid CategoriaId) : IRequest<BaseResponse>;