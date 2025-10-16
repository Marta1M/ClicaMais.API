using ClicaMais.Application.DTO;
namespace ClicaMais.Application.UseCases.Jogador.BuscarDados;

public class BuscarResponse
{
    public Guid Id { get; set; }
    public string Email { get; set; } = default!;
    public string Nome { get; set; } = default!;
    public string Senha { get; set; } = default!;
    public NivelDto NivelAtual { get; set; } = default!;
    public int NivelAtualId { get; set; } = default!;
    public decimal SaldoDeCliques { get; set; }
    public decimal SaldoAcumulado { get; set; }
    public DateTime CriadoEm { get; set; }
}