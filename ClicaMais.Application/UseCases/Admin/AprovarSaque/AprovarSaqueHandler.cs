using ClicaMais.Domain.Repositories;
using MediatR;

namespace ClicaMais.Application.UseCases.Admin.AprovarSaque;

public class AprovarSaqueHandler : IRequestHandler<AprovarSaqueRequest, Unit>
{
    private readonly ISaqueRepository _saqueRepository;

    public AprovarSaqueHandler(ISaqueRepository saqueRepository)
    {
        _saqueRepository = saqueRepository;
    }
    public async Task<Unit> Handle(AprovarSaqueRequest request, CancellationToken cancellationToken)
    {
        var saque = await _saqueRepository.ObterPorIdAsync(request.SaqueId);
        if (saque == null || saque.Status != "Pendente")
            throw new Exception("Saque inválido ou já aprovado.");

        saque.Aprovar(request.Referencia, request.Pin, request.Obs);
        await _saqueRepository.AtualizarAsync(saque);

        return Unit.Value;
    }
}