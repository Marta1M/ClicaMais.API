using System.ComponentModel.DataAnnotations.Schema;
using BCrypt.Net;

namespace ClicaMais.Domain.Models;

[Table("Jogadores")]
public class Jogador
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Senha { get; private set; } = default!;
    public int NivelAtualId { get; set; }
    public Nivel NivelAtual { get; set; }
    public decimal SaldoDeCliques { get; set; } = 0;
    public decimal SaldoAcumulado { get; set; } = 0;
    public DateTime CriadoEm { get; set; } = DateTime.UtcNow;

    public Jogador(string nome, string email)
    {
        Nome = nome;
        Email = email;
        NivelAtual = default!;
    }
    public void CriarNivel(Nivel novoNivel)
    {
        NivelAtual = novoNivel;
    }
    public void RegistrarClique(decimal valorPorClique)
    {
        SaldoDeCliques += valorPorClique;
    }
    public bool PodeSubirDeNivel(decimal metaNivel)
    {
        return SaldoDeCliques >= metaNivel;
    }
    public void SubirDeNivel(Nivel novoNivel)
    {
        if (!PodeSubirDeNivel(NivelAtual.ValorMetaNivel))
            throw new InvalidOperationException("Saldo insuficiente para subir de nível.");
        var resto = SaldoDeCliques - NivelAtual.ValorMetaNivel;
        //SaldoAcumulado += resto;
        SaldoDeCliques = resto;
        NivelAtual = novoNivel;
    }
    public bool PodeSacar()
    {
        return (SaldoAcumulado + SaldoDeCliques) >= 1000;
    }
    public Saque SolicitarSaque()
    {
        if (!PodeSacar())
            throw new InvalidOperationException("Saldo insuficiente para saque.");

        var valorParaSaque = CalcularValorDisponivelParaSaque();

        var restante = valorParaSaque;
        decimal aux = 0;

        if (SaldoAcumulado >= restante)
        {
            SaldoAcumulado -= restante;
        }
        else
        {
            aux = restante - SaldoAcumulado;
            SaldoAcumulado = 0;
            SaldoDeCliques -= aux;
        }

        return new Saque
        {
            JogadorId = Id,
            ValorSolicitado = valorParaSaque
        };
    }
    public void DefinirSenha(string senha)
    {
        Senha = BCrypt.Net.BCrypt.HashPassword(senha);
    }
    public bool VerificarSenha(string senha)
    {
        return BCrypt.Net.BCrypt.Verify(senha, Senha);
    }
    public int CalcularValorDisponivelParaSaque()
    {
        var total = SaldoAcumulado + SaldoDeCliques;
        return (int)(Math.Truncate(total / 1000) * 1000);
    }
}