public enum TipoTransacao
{
    Entrada,
    Saida
}

public class Transacao
{
    public TipoTransacao Tipo { get; set; }
    public decimal Valor { get; set; }
    public string Descricao { get; set; }

    public Transacao(TipoTransacao tipo, decimal valor, string descricao)
    {
        Tipo = tipo;
        Valor = valor;
        Descricao = descricao;
    }
}