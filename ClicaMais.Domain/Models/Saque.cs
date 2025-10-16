using System.ComponentModel.DataAnnotations.Schema;

namespace ClicaMais.Domain.Models;
[Table("Saques")]
public class Saque
{
    public Guid Id { get; set; }
    public Guid JogadorId { get; set; }
    public decimal ValorSolicitado { get; set; }
    public string Status { get; set; } = "Pendente"; //Pendente, Aprovado, Rejeitado
    public string Observacoes { get; set; } = default!;
    public string Pin { get; set; } = default!;
    public string Referencia { get; set; } = default!;
    public DateTime DataSolicitacao { get; set; }
    public DateTime DataProcessamento { get; set; }

    public void MarcarComoProcessado(string obs)
    {
        Status = "Processado";
        DataProcessamento = DateTime.UtcNow;
        Observacoes = obs;
    }
    public void MarcarComoAprovado(string obs)
    {
        Status = "Aprovado";
        Observacoes = obs;
    }
    public void Processar(string obs)
    {
        MarcarComoProcessado(obs);
    }
    public void Rejeitar(string obs)
    {
        MarcarComoRejeitado(obs);
    }
    public void Aprovar(string referencia, string pin, string obs)
    {
        MarcarComoAprovado(obs);
        Pin = pin;
        Referencia = referencia;
    }
    public void MarcarComoRejeitado(string obs)
    {
        Status = "Rejeitado";
        Observacoes = obs;
    }
}