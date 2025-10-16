using MediatR;
namespace ClicaMais.Application.UseCases.Admin.AprovarSaque;

public class AprovarSaqueRequest : IRequest<Unit>
{
    public Guid SaqueId { get; set; }
    public string Referencia { get; set; } = default!;
    public string Pin { get; set; } = default!;
    public string Obs { get; set; } = default!;
}