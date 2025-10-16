using ClicaMais.Domain.Models;

namespace ClicaMais.Application.Services;

public interface INivelService
{
    Task<Nivel> ObterNivelAsync(int numeroNivel);
}