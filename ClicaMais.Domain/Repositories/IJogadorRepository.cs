using ClicaMais.Domain.Models;

namespace ClicaMais.Domain.Repositories;

public interface IJogadorRepository
{
    Task<Jogador?> ObterPorIdAsync(Guid id);
    Task<Jogador?> ObterPorEmailAsync(string email);
    Task CriarAsync(Jogador jogador);
    Task AtualizarAsync(Jogador jogador);
    Task<bool> ExisteEmailAsync(string email);
}