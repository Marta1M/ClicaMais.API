using ClicaMais.Application.Services;
using ClicaMais.Application.UseCases.Admin.CriarNivel;
using ClicaMais.Domain.Repositories;
using MediatR;

namespace ClicaMais.Application.UseCases.Admin;

public class CriarNivelHandler : IRequestHandler<CriarNivelRequest, CriarNivelResponse>
{
    private readonly INivelRepository _nivelRepository;
    private readonly INivelService _nivelService;
    public CriarNivelHandler(
        INivelRepository nivelRepository,
        INivelService nivelService)
    {
        _nivelRepository = nivelRepository;
        _nivelService = nivelService;
    }
    public async Task<CriarNivelResponse> Handle(CriarNivelRequest request, CancellationToken cancellationToken)
    {

        var nivel = await _nivelService.ObterNivelAsync(request.Numero);

        await _nivelRepository.CriarAsync(nivel);

        return new CriarNivelResponse
        {
            Numero = nivel.Numero,
            ValorPorClique = nivel.ValorPorClique,
            ValorMetaNivel = nivel.ValorMetaNivel
        };
    }
}