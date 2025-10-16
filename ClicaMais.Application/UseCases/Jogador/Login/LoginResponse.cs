namespace ClicaMais.Application.UseCases.Jogador.Login;

public class LoginResponse
{
    public Guid Id { get; set; }
    public string Email { get; set; } = default!;
    public string Nome { get; set; } = default!;
    public string Senha { get; set; } = default!;
}