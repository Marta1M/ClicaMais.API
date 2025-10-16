using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClicaMais.Domain.Models;
[Table("Niveis")]
public class Nivel
{
    [Key]
    public int Id { get; set; }
    public int Numero { get; set; }
    public decimal ValorPorClique { get; set; }
    public decimal ValorMetaNivel { get; set; }
    public Nivel()
    {
    }
    public Nivel(int numeroNivel, decimal valorPorClique, decimal valorMetaNivel)
    {
        Numero = numeroNivel;
        ValorPorClique = valorPorClique;
        ValorMetaNivel = valorMetaNivel;
    }
}