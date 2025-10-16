using ClicaMais.Application.DTO;

namespace ClicaMais.Application.UseCases.Admin.ListarTodosSaques;

public class TodosSaquesResponse
{
    public Guid JogadorId { get; set; }
    public required JogadorDto Jogador { get; set; }
    public Guid SaqueId { get; set; }
    public decimal ValorSolicitado { get; set; }
    public DateTime DataSolicitacao { get; set; }
    public DateTime DataProcessamento { get; set; }
    public required string Status { get; set; }
}