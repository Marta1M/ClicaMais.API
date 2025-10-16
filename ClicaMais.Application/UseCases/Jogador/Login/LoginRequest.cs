using MediatR;
namespace ClicaMais.Application.UseCases.Jogador.Login;

public class LoginRequest : IRequest<LoginResponse>
{
    public string Email { get; set; } = default!;
    public string Senha { get; set; } = default!;
}