using System.Collections.Generic;
using System.Linq;

namespace FinanceApp.Models;

public class RelatorioFinanceiro
{
    public decimal TotalReceitas { get; private set; }
    public decimal TotalDespesas { get; private set; }
    public decimal Saldo => TotalReceitas - TotalDespesas;

    public decimal TotalInvestido { get; private set; }
    public decimal TotalPrevistoInvestimentos { get; private set; }

    public RelatorioFinanceiro(
        List<Transacao> transacoes,
        List<Investimento> investimentos)
    {
        CalcularTransacoes(transacoes);
        CalcularInvestimentos(investimentos);
    }

    private void CalcularTransacoes(List<Transacao> transacoes)
    {
        TotalReceitas = transacoes
            .Where(t => t.Tipo == "Receita")
            .Sum(t => t.Valor);

        TotalDespesas = transacoes
            .Where(t => t.Tipo == "Despesa")
            .Sum(t => t.Valor);
    }

    private void CalcularInvestimentos(List<Investimento> investimentos)
    {
        TotalInvestido = investimentos.Sum(i => i.ValorInicial);
        TotalPrevistoInvestimentos = investimentos.Sum(i => i.ValorFinalPrevisto);
    }
}
