using ClicaMais.Domain.Models;

namespace ClicaMais.Application.Services;

public class NivelService : INivelService
{
    public Task<Nivel> ObterNivelAsync(int numeroNivel)
    {
        return Task.FromResult( new Nivel(
            numeroNivel,
            (decimal) Math.Round(1 * Math.Pow(1 + 0.45, numeroNivel-1), 2),
            (decimal) Math.Round(1000 * Math.Pow(1 + 1.0, numeroNivel-1), 2)
        ));
    }
}