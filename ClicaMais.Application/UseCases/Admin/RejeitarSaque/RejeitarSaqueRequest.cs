using MediatR;
namespace ClicaMais.Application.UseCases.Admin.RejeitarSaque;

public class RejeitarSaqueRequest : IRequest<Unit>
{
    public Guid SaqueId { get; set; }
    public string Obs { get; set; } = default!;
}