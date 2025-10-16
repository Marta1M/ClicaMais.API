using ClicaMais.Domain.Repositories;
using MediatR;

namespace ClicaMais.Application.UseCases.Jogador.SolicitarSaque;

public class SolicitarSaqueHandler : IRequestHandler<SolicitarSaqueRequest, SolicitarSaqueResponse>
{
    private readonly IJogadorRepository _jogadorRepository;
    private readonly ISaqueRepository _saqueRepository;
    public SolicitarSaqueHandler(
        IJogadorRepository jogadorRepository,
        ISaqueRepository saqueRepository)
    {
        _jogadorRepository = jogadorRepository;
        _saqueRepository = saqueRepository;
    }

    public async Task<SolicitarSaqueResponse> Handle(SolicitarSaqueRequest request, CancellationToken cancellationToken)
    {
        var jogador = await _jogadorRepository.ObterPorIdAsync(request.JogadorId);
        if (jogador == null)
            throw new Exception("Jogador não encontrado.");
        var solicitacao = jogador.SolicitarSaque();

        await _jogadorRepository.AtualizarAsync(jogador);
        await _saqueRepository.RegistrarAsync(solicitacao);

        return new SolicitarSaqueResponse
        {
            ValorSolicitado = solicitacao.ValorSolicitado,
            Mensagem = "Saque solicitado com sucesso. Aguarde até 48 horas."
        };
    }
}