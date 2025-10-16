using MediatR;

namespace ClicaMais.Application.UseCases.Jogador.SubirNivel;

public class SubirNivelRequest : IRequest<SubirNivelResponse>
{
    public Guid JogadorId { get; set; }
    public SubirNivelRequest(Guid jogadorId)
    {
        JogadorId = jogadorId;
    }
}