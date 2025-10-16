using ClicaMais.Domain.Repositories;
using MediatR;

namespace ClicaMais.Application.UseCases.Jogador.Saques;

public class SaquesHandler : IRequestHandler<SaquesRequest, List<SaquesResponse>>
{
    private readonly ISaqueRepository _saquesRepository;

    public SaquesHandler(ISaqueRepository saquesRepository)
    {
        _saquesRepository = saquesRepository;
    }
    public async Task<List<SaquesResponse>> Handle(SaquesRequest request, CancellationToken cancellationToken)
    {
        var saques = await _saquesRepository.ObterPorJogadorIdAsync(request.JogadorId);

        if(saques == null)
            throw new Exception("Não possui saques!.");
 
        return saques.Select(s => new SaquesResponse
        {
            Id = s.Id,
            ValorSolicitado = s.ValorSolicitado,
            Status = s.Status,
            Observacoes = s.Observacoes,
            Pin = s.Pin,
            Referencia = s.Referencia,
            DataSolicitacao = s.DataSolicitacao,
            DataProcessamento = s.DataProcessamento
        }).ToList();
    }
}