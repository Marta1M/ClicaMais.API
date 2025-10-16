namespace ClicaMais.Application.UseCases.Admin.ListarSaquesPendentes;

public class SaquesPendentesResponse
{
    public Guid JogadorId { get; set; }
    public Guid SaqueId { get; set; }
    public decimal ValorSolicitado { get; set; }
    public DateTime DataSolicitacao { get; set; }
}