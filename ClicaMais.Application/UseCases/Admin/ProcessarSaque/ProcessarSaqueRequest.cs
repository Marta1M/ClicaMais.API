using MediatR;
namespace ClicaMais.Application.UseCases.Admin.ProcessarSaque;

public class ProcessarSaqueRequest : IRequest<Unit>
{
    public Guid SaqueId { get; set; }
    public string Obs { get; set; } = default!;
}