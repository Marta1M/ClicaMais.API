using MediatR;
namespace ClicaMais.Application.UseCases.Jogador.BuscarDados;

public class BuscarRequest : IRequest<BuscarResponse>
{
    public Guid JogadorId { get; set; } = default!;
    public BuscarRequest(Guid jogadorId)
    {
        JogadorId = jogadorId;
    }
}