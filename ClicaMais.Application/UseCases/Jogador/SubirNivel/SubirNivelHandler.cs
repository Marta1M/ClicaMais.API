using ClicaMais.Application.Services;
using ClicaMais.Domain.Repositories;
using MediatR;

namespace ClicaMais.Application.UseCases.Jogador.SubirNivel;

public class SubirNivelHandler : IRequestHandler<SubirNivelRequest, SubirNivelResponse>
{
    private readonly IJogadorRepository _jogadorRepository;
    private readonly INivelRepository _nivelRepository;
    public SubirNivelHandler(
        IJogadorRepository jogadorRepository,
        INivelRepository nivelRepository)
    {
        _jogadorRepository = jogadorRepository;
        _nivelRepository = nivelRepository;
    }
    public async Task<SubirNivelResponse> Handle(SubirNivelRequest request, CancellationToken cancellationToken)
    {
        var jogador = await _jogadorRepository.ObterPorIdAsync(request.JogadorId);
        if (jogador == null)
            throw new Exception("Jogador não encontrado.");

        var proximoNivel = await _nivelRepository.ObterPorNumeroAsync(jogador.NivelAtual.Numero + 1);
        if (proximoNivel == null)
            throw new Exception("Nível não encontrado.");

        jogador.SubirDeNivel(proximoNivel);
        await _jogadorRepository.AtualizarAsync(jogador);

        return new SubirNivelResponse
        {
            NovoNivel = jogador.NivelAtual,
            SaldoAtual = jogador.SaldoDeCliques,
            SaldoAcumulado = jogador.SaldoAcumulado
        };
    }
}