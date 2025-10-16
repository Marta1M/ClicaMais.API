using ClicaMais.Domain.Repositories;
using MediatR;

namespace ClicaMais.Application.UseCases.Jogador.Login;

public class LoginHandler : IRequestHandler<LoginRequest, LoginResponse>
{
    private readonly IJogadorRepository _jogadorRepository;

    public LoginHandler(IJogadorRepository jogadorRepository)
    {
        _jogadorRepository = jogadorRepository;
    }
    public async Task<LoginResponse> Handle(LoginRequest request, CancellationToken cancellationToken)
    {
        var jogador = await _jogadorRepository.ObterPorEmailAsync(request.Email) ??
            throw new Exception("Jogador não encontrado.");

        if (!jogador.VerificarSenha(request.Senha))
            throw new Exception("Email ou senha inválidos.");
            
        return new LoginResponse
        {
            Id = jogador.Id,
            Nome = jogador.Nome,
            Email = jogador.Email,
            Senha = jogador.Senha
        };
    }
}