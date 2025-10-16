using ClicaMais.Domain.Models;

namespace ClicaMais.Domain.Repositories;

public interface ISaqueRepository
{
    Task RegistrarAsync(Saque saque);
    Task<Saque?> ObterPorIdAsync(Guid id);
    Task<List<Saque>> ObterPorJogadorIdAsync(Guid id);
    Task AtualizarAsync(Saque saque);
    Task<List<Saque>> ObterPendentesAsync();
    Task<List<Saque>> ObterTodosAsync();
}