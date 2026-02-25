namespace FinanceApp.Models;

public class Transacao
{
    public string Tipo { get; set; } = "";
    public decimal Valor { get; set; }
    public string Descricao { get; set; } = "";

    // ✅ Construtor vazio (necessário para o JSON)
    public Transacao()
    {
    }

    // ✅ Construtor normal
    public Transacao(string tipo, decimal valor, string descricao)
    {
        Tipo = tipo;
        Valor = valor;
        Descricao = descricao;
    }

    public override string ToString()
    {
        return $"{Tipo} | {Descricao} | {Valor:C}";
    }
}
