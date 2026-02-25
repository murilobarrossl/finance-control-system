using System;

namespace FinanceApp.Web.Models
{
    public class Investimento
    {
        public string Descricao { get; set; } = string.Empty;
        public decimal ValorInicial { get; set; }
        public decimal TaxaMensal { get; set; }
        public int Meses { get; set; }

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
    }
}
