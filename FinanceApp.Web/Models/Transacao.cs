using System.ComponentModel.DataAnnotations;

namespace FinanceApp.Web.Models;

public enum TipoTransacao
{
    Entrada,
    Saida
}

public class Transacao
{
    public Transacao(string tipo, decimal valor, string descricao)
    {
        Valor = valor;
        Descricao = descricao;
    }

    public int Id { get; set; }

    [Required]
    public TipoTransacao Tipo { get; set; }

    [Required]
    [Range(0.01, double.MaxValue)]
    public decimal Valor { get; set; }

    [Required]
    [StringLength(100)]
    public string Descricao { get; set; } = "";

    [Required]
    public DateTime Data { get; set; } = DateTime.Now;
}
