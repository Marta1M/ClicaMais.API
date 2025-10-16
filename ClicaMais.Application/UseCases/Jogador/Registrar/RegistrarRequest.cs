using MediatR;
namespace ClicaMais.Application.UseCases.Jogador.Registrar;

public class RegistrarRequest : IRequest<RegistrarResponse>
{
    public string Email { get; set; } = default!;
    public string Nome { get; set; } = default!;
    public string Senha { get; set; } = default!;
}