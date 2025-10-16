using MediatR;
namespace ClicaMais.Application.UseCases.Jogador.RegistrarClique;

public class RegistrarCliqueRequest : IRequest<RegistrarCliqueResponse>
{
    public Guid JogadorId { get; set; }
}