using MediatR;
namespace ClicaMais.Application.UseCases.Jogador.Saques;

public class SaquesRequest : IRequest<List<SaquesResponse>>
{
    public Guid JogadorId { get; set; } = default!;
    public SaquesRequest(Guid jogadorId)
    {
        JogadorId = jogadorId;
    }
}