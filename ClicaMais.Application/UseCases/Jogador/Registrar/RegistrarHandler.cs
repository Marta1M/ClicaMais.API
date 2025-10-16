using ClicaMais.Domain.Repositories;
using MediatR;

namespace ClicaMais.Application.UseCases.Jogador.Registrar;

public class RegistrarHandler : IRequestHandler<RegistrarRequest, RegistrarResponse>
{
    private readonly IJogadorRepository _jogadorRepository;
    private readonly INivelRepository _nivelRepository;

    public RegistrarHandler(
        IJogadorRepository jogadorRepository,
        INivelRepository nivelRepository)
    {
        _jogadorRepository = jogadorRepository;
        _nivelRepository = nivelRepository;
    }
    public async Task<RegistrarResponse> Handle(RegistrarRequest request, CancellationToken cancellationToken)
    {
        if (await _jogadorRepository.ExisteEmailAsync(request.Email))
            throw new Exception("Já existe jogador registrado com este e-mail.");

        var jogador = new Domain.Models.Jogador(request.Nome, request.Email);
        var nivel = await _nivelRepository.ObterPorNumeroAsync(1);

        if (nivel == null)
            throw new Exception("Nível não encontrado.");

        jogador.DefinirSenha(request.Senha);
        jogador.CriarNivel(nivel);

        await _jogadorRepository.CriarAsync(jogador);
 
        return new RegistrarResponse
        {
            Id = jogador.Id,
            Nome = jogador.Nome,
            Email = jogador.Email,
            Senha = jogador.Senha
        };
    }
}