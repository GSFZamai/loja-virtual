using BkVirtual.Application.Handlers.ProdutoHandler.Cadastrar;
using BkVirtual.Application.Handlers.ProdutoHandler.Editar;
using BkVirtual.Application.Handlers.ProdutoHandler.Listar;
using BkVirtual.Application.Handlers.ProdutoHandler.ListarPorId;
using BkVirtual.Core.DTOs;
using BkVirtual.Core.NotificationError;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BkVirtual.WEB.Controllers;

[Route("[controller]")]
public class ProdutosController : MainController
{
    public ProdutosController(
        IMediator mediator,
        INotificationHandler<NotificacaoErro> notificationHandler) : base(mediator, notificationHandler)
    {
    }
    
    [HttpPost]
    public async Task<IActionResult> CadastrarProdutoAsync([FromBody] CadastrarProdutoRequest request)
    {
        var resultado = await Mediator.Send(request);

        if (ProcessoInvalido())
            return BadRequest(BaseResponse.Erro(ObterErros));

        return Ok(resultado);
    }

    [HttpGet]
    public async Task<IActionResult> ListarCategoriaAsync([FromQuery] ListarProdutoRequest categoriaRequest)
    {
        var resultado = await Mediator.Send(categoriaRequest);

        if (ProcessoInvalido())
            return BadRequest(BaseResponse.Erro(ObterErros));

        return Ok(resultado);
    }
    
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> ListarProdutoPorIdAsync(Guid id)
    {
        var resultado = await Mediator.Send(new ListarProdutoPorIdRequest(id));

        if (ProcessoInvalido())
            return BadRequest(BaseResponse.Erro(ObterErros));

        return Ok(resultado);
    }
    
    [HttpPatch("{id:guid}")]
    public async Task<IActionResult> EditarProdutoAsync(Guid id, [FromBody] EditarProdutoRequest request)
    {
        if (id != request.Id)
            return BadRequest(BaseResponse.Erro(new List<NotificacaoErro>
            {
                new(nameof(EditarProdutoRequest), "Erro ao editar produto.")
            }));
        
        var resultado = await Mediator.Send(request);

        if (ProcessoInvalido())
            return BadRequest(BaseResponse.Erro(ObterErros));

        return Ok(resultado);
    }
}