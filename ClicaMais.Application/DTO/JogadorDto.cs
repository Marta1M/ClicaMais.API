namespace ClicaMais.Application.DTO;
public class JogadorDto
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = default!;
    public string Email { get; set; } = default!;
    public NivelDto NivelAtual { get; set; } = default!;
    public decimal SaldoDeCliques { get; set; } = 0;
    public decimal SaldoAcumulado { get; set; } = 0;
    public DateTime CriadoEm { get; set; } = DateTime.UtcNow;
}