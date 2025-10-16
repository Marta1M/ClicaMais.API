using MediatR;

namespace ClicaMais.Application.UseCases.Jogador.SolicitarSaque;
public class SolicitarSaqueRequest : IRequest<SolicitarSaqueResponse>
{
    public Guid JogadorId { get; set; }
}