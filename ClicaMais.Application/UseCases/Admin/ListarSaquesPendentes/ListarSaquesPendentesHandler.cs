using ClicaMais.Domain.Repositories;
using MediatR;

namespace ClicaMais.Application.UseCases.Admin.ListarSaquesPendentes;

public class ListarSaquesPendentesHandler : IRequestHandler<ListarSaquesPendentesRequest, List<SaquesPendentesResponse>>
{
    private readonly ISaqueRepository _saqueRepository;

    public ListarSaquesPendentesHandler(ISaqueRepository saqueRepository)
    {
        _saqueRepository = saqueRepository;
    }
    public async Task<List<SaquesPendentesResponse>> Handle(ListarSaquesPendentesRequest request, CancellationToken cancellationToken)
    {
        var saques = await _saqueRepository.ObterPendentesAsync();

        return saques.Select(s => new SaquesPendentesResponse
        {
            JogadorId = s.JogadorId,
            SaqueId = s.Id,
            ValorSolicitado = s.ValorSolicitado,
            DataSolicitacao = s.DataSolicitacao
        }).ToList();
    }
}