using ClicaMais.Domain.Models;

namespace ClicaMais.Domain.Repositories;

public interface INivelRepository
{
    Task<Nivel?> ObterPorIdAsync(int id);
    Task<List<Nivel>> ObterTodosAsync();
    Task CriarAsync(Nivel nivel);
    Task AtualizarAsync(Nivel nivel);
    Task<Nivel?> ObterPorNumeroAsync(int num);
}