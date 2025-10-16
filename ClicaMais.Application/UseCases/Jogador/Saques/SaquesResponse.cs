using ClicaMais.Application.DTO;
namespace ClicaMais.Application.UseCases.Jogador.Saques;

public class SaquesResponse
{
    public Guid Id { get; set; }
    public decimal ValorSolicitado { get; set; }
    public string Status { get; set; } = default!;
    public string Observacoes { get; set; } = default!;
    public string Pin { get; set; } = default!;
    public string Referencia { get; set; } = default!;
    public DateTime DataSolicitacao { get; set; }
    public DateTime DataProcessamento { get; set; }
}