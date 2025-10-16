using ClicaMais.Application.UseCases.Jogador.Saques;
using ClicaMais.Application.UseCases.Jogador.BuscarDados;
using ClicaMais.Application.UseCases.Jogador.RegistrarClique;
using ClicaMais.Application.UseCases.Jogador.Registrar;
using ClicaMais.Application.UseCases.Jogador.Login;
using ClicaMais.Application.UseCases.Jogador.SolicitarSaque;
using ClicaMais.Application.UseCases.Jogador.SubirNivel;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace ClicaMais.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class JogadorController : ControllerBase
{
    private readonly IMediator _mediator;
    public JogadorController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpPost("clique")]
    public async Task<IActionResult> RegistrarClique([FromBody] RegistrarCliqueRequest request)
    {
        var result = await _mediator.Send(request);
        return Ok(result);
    }
    [HttpPost("criar")]
    public async Task<IActionResult> Criar([FromBody] RegistrarRequest request)
    {
        var result = await _mediator.Send(request);
        return Ok(result);
    }
    [HttpPost("sacar")]
    public async Task<IActionResult> SolicitarSaque([FromBody] SolicitarSaqueRequest request)
    {
        var result = await _mediator.Send(request);
        return Ok(result);
    }
    [HttpPost("subir-nivel")]
    public async Task<IActionResult> SubirNivel([FromBody] SubirNivelRequest request)
    {
        var result = await _mediator.Send(request);
        return Ok(result);
    }
    [HttpGet("id")]
    public async Task<IActionResult> ObterPorId(Guid id)
    {
        var Jogador = await _mediator.Send(new BuscarRequest(id));
        if(Jogador == null)
            return NotFound();
        return Ok(Jogador);
    }
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var Jogador = await _mediator.Send(request);
        return Ok(Jogador);
    }
    [HttpGet("{jogadorId}/saques")]
    public async Task<IActionResult> ObterSaques(Guid jogadorId)
    {
        var saques = await _mediator.Send(new SaquesRequest(jogadorId));
        if(saques == null)
            return NotFound();
        return Ok(saques);
    }

}