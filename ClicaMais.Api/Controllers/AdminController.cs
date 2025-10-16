using ClicaMais.Application.UseCases.Admin.AprovarSaque;
using ClicaMais.Application.UseCases.Admin.CriarNivel;
using ClicaMais.Application.UseCases.Admin.ListarSaquesPendentes;
using ClicaMais.Application.UseCases.Admin.ListarTodosSaques;
using ClicaMais.Application.UseCases.Admin.ProcessarSaque;
using ClicaMais.Application.UseCases.Admin.RejeitarSaque;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClicaMais.API.Controllers;

[ApiController]
[Route("api/admin")]
public class AdminController : ControllerBase
{
    private readonly IMediator _mediator;
    public AdminController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("saques/pedentes")]
    public async Task<IActionResult> ListarPendentes()
    {
        var result = await _mediator.Send(new ListarSaquesPendentesRequest());
        return Ok(result);

    }
    [HttpGet("saques/todos")]
    public async Task<IActionResult> ListarTodos()
    {
        var result = await _mediator.Send(new ListarTodosSaquesRequest());
        return Ok(result);

    }
    [HttpPost("saques/{id}/processar")]
    public async Task<IActionResult> Processar(Guid id, [FromBody] ProcessarSaqueRequest request)
    {
        var result = await _mediator.Send(request);
        return Ok(result); 
    }
    [HttpPost("saques/{id}/aprovar")]
    public async Task<IActionResult> Aprovar(Guid id, [FromBody] AprovarSaqueRequest request)
    {
        request.SaqueId = id;
        var result = await _mediator.Send(request);
        return Ok(result);
    }
    [HttpPost("saques/{id}/rejeitar")]
    public async Task<IActionResult> Rejeitar(Guid id, [FromBody] RejeitarSaqueRequest request)
    {
        request.SaqueId = id;
        var result = await _mediator.Send(request);
        return Ok(result);
    }
    [HttpPost("criarNivel")]
    public async Task<IActionResult> CriarNivel([FromBody] CriarNivelRequest request)
    {
        var result = await _mediator.Send(request);
        return Ok(result);
    }
    
}