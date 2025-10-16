using ClicaMais.Application.Services;
using ClicaMais.Domain.Repositories;
using MediatR;

namespace ClicaMais.Application.UseCases.Jogador.RegistrarClique;

public class RegistrarCliqueHandler : IRequestHandler<RegistrarCliqueRequest, RegistrarCliqueResponse>
{
    private readonly IJogadorRepository _jogadorRepository;
    private readonly INivelService _nivelService;

    public RegistrarCliqueHandler(IJogadorRepository jogadorRepository, INivelService nivelService)
    {
        _jogadorRepository = jogadorRepository;
        _nivelService = nivelService;
    }
    public async Task<RegistrarCliqueResponse> Handle(RegistrarCliqueRequest request, CancellationToken cancellationToken)
    {
        var jogador = await _jogadorRepository.ObterPorIdAsync(request.JogadorId);
        if (jogador == null)
            throw new Exception("Jogador não encontrado.");

        var nivel = await _nivelService.ObterNivelAsync(jogador.NivelAtual.Numero);
        jogador.RegistrarClique(nivel.ValorPorClique);

        await _jogadorRepository.AtualizarAsync(jogador);

        return new RegistrarCliqueResponse
        {
            NovoSaldo = jogador.SaldoDeCliques
        };
    }
}