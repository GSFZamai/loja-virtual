using BkVirtual.Core.DTOs;
using MediatR;

namespace BkVirtual.Application.DTOs;

public record PaginacaoRequest : IRequest<BaseResponse>
{
    public int Indice { get; set; }
    public int TamanhoPagina { get; set; }
}