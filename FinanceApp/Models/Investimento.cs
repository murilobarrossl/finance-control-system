using System;

namespace FinanceApp.Models
{
    public class Investimento
    {
        public string Descricao { get; set; } = string.Empty;
        public decimal ValorInicial { get; set; }
        public decimal TaxaMensal { get; set; }
        public int Meses { get; set; }
        public decimal ValorFinalPrevisto => CalcularValorFinal();

        // Construtor vazio (necessário para JSON)
        public Investimento()
        {
        }

        // Construtor principal
        public Investimento(string descricao, decimal valorInicial, decimal taxaMensal, int meses)
        {
            Descricao = descricao;
            ValorInicial = valorInicial;
            TaxaMensal = taxaMensal;
            Meses = meses;
        }

        public decimal CalcularValorFinal()
        {
            decimal montante = ValorInicial;

            for (int i = 0; i < Meses; i++)
            {
                montante += montante * (TaxaMensal / 100);
            }

            return Math.Round(montante, 2);
        }

        public decimal CalcularLucro()
        {
            return Math.Round(CalcularValorFinal() - ValorInicial, 2);
        }

        public decimal CalcularPercentualLucro()
        {
            if (ValorInicial == 0)
                return 0;

            return Math.Round((CalcularLucro() / ValorInicial) * 100, 2);
        }

        public string GerarResumo()
        {
            return $"""
            ------------------------------
            Investimento: {Descricao}
            Valor Inicial: R$ {ValorInicial:N2}
            Taxa Mensal: {TaxaMensal}% 
            Período: {Meses} meses
            Valor Final: R$ {CalcularValorFinal():N2}
            Lucro: R$ {CalcularLucro():N2} ({CalcularPercentualLucro():N2}%)
            ------------------------------
            """;
        }
    }
}
