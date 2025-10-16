using ClicaMais.Application.DTO;
using ClicaMais.Domain.Repositories;
using MediatR;

namespace ClicaMais.Application.UseCases.Admin.ListarTodosSaques;

public class ListarTodosSaquesHandler : IRequestHandler<ListarTodosSaquesRequest, List<TodosSaquesResponse>>
{
    private readonly ISaqueRepository _saqueRepository;
    private readonly IJogadorRepository _jogadorRepository;

    public ListarTodosSaquesHandler(
        ISaqueRepository saqueRepository,
        IJogadorRepository jogadorRepository)
    {
        _saqueRepository = saqueRepository;
        _jogadorRepository = jogadorRepository;
    }
    public async Task<List<TodosSaquesResponse>> Handle(ListarTodosSaquesRequest request, CancellationToken cancellationToken)
    {
        var saques = await _saqueRepository.ObterTodosAsync();
        var response = new List<TodosSaquesResponse>();

        foreach (var s in saques)
        {
            var jogador = await _jogadorRepository.ObterPorIdAsync(s.JogadorId);
            if (jogador == null) break;
            response.Add(new TodosSaquesResponse
            {
                SaqueId = s.Id,
                Status = s.Status,
                JogadorId = s.JogadorId,
                Jogador = new JogadorDto
                {
                    Nome = jogador.Nome,
                    Id = jogador.Id,
                    Email = jogador.Email,
                    NivelAtual = new NivelDto
                    {
                        Numero = jogador.NivelAtual.Numero,
                        ValorPorClique = jogador.NivelAtual.ValorPorClique,
                        ValorMetaNivel = jogador.NivelAtual.ValorMetaNivel
                    },
                    SaldoDeCliques = jogador.SaldoDeCliques,
                    SaldoAcumulado = jogador.SaldoAcumulado,
                    CriadoEm = jogador.CriadoEm
                },
                ValorSolicitado = s.ValorSolicitado,
                DataSolicitacao = s.DataSolicitacao,
                DataProcessamento = s.DataProcessamento
            });
#pragma warning restore CS8602 // Dereference of a possibly null reference.
        }
        return response;
    }
}