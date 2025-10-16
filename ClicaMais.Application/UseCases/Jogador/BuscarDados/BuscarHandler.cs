using ClicaMais.Domain.Repositories;
using ClicaMais.Application.DTO;
using MediatR;

namespace ClicaMais.Application.UseCases.Jogador.BuscarDados;

public class BuscarHandler : IRequestHandler<BuscarRequest, BuscarResponse>
{
    private readonly IJogadorRepository _jogadorRepository;

    public BuscarHandler(IJogadorRepository jogadorRepository)
    {
        _jogadorRepository = jogadorRepository;
    }
    public async Task<BuscarResponse> Handle(BuscarRequest request, CancellationToken cancellationToken)
    {
        var jogador = await _jogadorRepository.ObterPorIdAsync(request.JogadorId);

        if(jogador == null)
            throw new Exception("Jogador não encontrado.");

        return new BuscarResponse
        {
            Id = jogador.Id,
            Nome = jogador.Nome,
            Senha = jogador.Senha,
            Email = jogador.Email,
            CriadoEm = jogador.CriadoEm,
            SaldoDeCliques = jogador.SaldoDeCliques,
            SaldoAcumulado = jogador.SaldoAcumulado,
            NivelAtualId = jogador.NivelAtualId,
            NivelAtual = new NivelDto
            {
                Numero = jogador.NivelAtual.Numero,
                ValorPorClique = jogador.NivelAtual.ValorPorClique,
                ValorMetaNivel = jogador.NivelAtual.ValorMetaNivel
            }
        };
    }
}