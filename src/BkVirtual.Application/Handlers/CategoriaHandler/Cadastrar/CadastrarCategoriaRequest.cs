using BkVirtual.Core.DTOs;
using MediatR;

namespace BkVirtual.Application.Handlers.CategoriaHandler.Cadastrar;

public record CadastrarCategoriaRequest(string Nome, string Descricao) : IRequest<BaseResponse>;
