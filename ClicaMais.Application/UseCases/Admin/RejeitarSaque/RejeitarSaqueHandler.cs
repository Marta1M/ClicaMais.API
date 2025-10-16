using ClicaMais.Domain.Repositories;
using MediatR;

namespace ClicaMais.Application.UseCases.Admin.RejeitarSaque;

public class RejeitarSaqueHandler : IRequestHandler<RejeitarSaqueRequest, Unit>
{
    private readonly ISaqueRepository _saqueRepository;

    public RejeitarSaqueHandler(ISaqueRepository saqueRepository)
    {
        _saqueRepository = saqueRepository;
    }
    public async Task<Unit> Handle(RejeitarSaqueRequest request, CancellationToken cancellationToken)
    {
        var saque = await _saqueRepository.ObterPorIdAsync(request.SaqueId);
        if (saque == null || saque.Status != "Pendente")
            throw new Exception("Saque inválido ou já rejeitado.");

        saque.Rejeitar(request.Obs);
        await _saqueRepository.AtualizarAsync(saque);

        return Unit.Value;
    }
}