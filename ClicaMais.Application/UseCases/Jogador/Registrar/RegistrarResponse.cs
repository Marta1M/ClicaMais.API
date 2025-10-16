namespace ClicaMais.Application.UseCases.Jogador.Registrar;

public class RegistrarResponse
{
    public Guid Id { get; set; }
    public string Email { get; set; } = default!;
    public string Nome { get; set; } = default!;
    public string Senha { get; set; } = default!;
}