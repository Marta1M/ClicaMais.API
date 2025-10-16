using ClicaMais.Domain.Repositories;
using MediatR;

namespace ClicaMais.Application.UseCases.Admin.ProcessarSaque;

public class ProcessarSaqueHandler : IRequestHandler<ProcessarSaqueRequest, Unit>
{
    private readonly ISaqueRepository _saqueRepository;

    public ProcessarSaqueHandler(ISaqueRepository saqueRepository)
    {
        _saqueRepository = saqueRepository;
    }
    public async Task<Unit> Handle(ProcessarSaqueRequest request, CancellationToken cancellationToken)
    {
        var saque = await _saqueRepository.ObterPorIdAsync(request.SaqueId);
        if (saque == null || saque.Status != "Aprovado")
            throw new Exception("Saque inválido ou já processado.");

        saque.Processar(request.Obs);
        await _saqueRepository.AtualizarAsync(saque);

        return Unit.Value;
    }
}