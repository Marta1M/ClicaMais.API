using ClicaMais.Domain.Models;

namespace ClicaMais.Application.UseCases.Jogador.SubirNivel;

public class SubirNivelResponse
{
    public Nivel? NovoNivel { get; set; } 
    public decimal SaldoAtual { get; set; }
    public decimal SaldoAcumulado { get; set; }
}