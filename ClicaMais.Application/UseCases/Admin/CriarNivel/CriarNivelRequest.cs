using MediatR;

namespace ClicaMais.Application.UseCases.Admin.CriarNivel;

public class CriarNivelRequest : IRequest<CriarNivelResponse>
{
    public int Numero { get; set; }
}