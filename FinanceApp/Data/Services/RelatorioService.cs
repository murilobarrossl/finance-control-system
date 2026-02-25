using FinanceApp.Models;

namespace FinanceApp.Services;

public static class RelatorioService
{
    public static void ExibirResumo(
        List<Transacao> transacoes,
        List<Investimento> investimentos)
    {
        Console.Clear();
        Console.WriteLine("========== RELATÓRIO GERAL ==========\n");

        ExibirResumoFinanceiro(transacoes);
        ExibirResumoInvestimentos(investimentos);

        Console.WriteLine("\nPressione qualquer tecla para voltar...");
        Console.ReadKey();
    }

    // ================= FINANCEIRO =================

    private static void ExibirResumoFinanceiro(List<Transacao> transacoes)
    {
        decimal totalReceitas = 0;
        decimal totalDespesas = 0;

        foreach (var t in transacoes)
        {
            if (t.Tipo == "Receita")
                totalReceitas += t.Valor;
            else if (t.Tipo == "Despesa")
                totalDespesas += t.Valor;
        }

        decimal saldo = totalReceitas - totalDespesas;

        Console.WriteLine("📊 FINANÇAS");
        Console.WriteLine($"Total de Receitas: {totalReceitas:C}");
        Console.WriteLine($"Total de Despesas: {totalDespesas:C}");
        Console.WriteLine($"Saldo Atual: {saldo:C}");

        if (saldo > 0)
            Console.WriteLine("Status: 🟢 Positivo");
        else if (saldo < 0)
            Console.WriteLine("Status: 🔴 Negativo");
        else
            Console.WriteLine("Status: ⚪ Zerado");

        Console.WriteLine();
    }

    // ================= INVESTIMENTOS =================

    private static void ExibirResumoInvestimentos(List<Investimento> investimentos)
    {
        Console.WriteLine("💰 INVESTIMENTOS");

        if (investimentos.Count == 0)
        {
            Console.WriteLine("Nenhum investimento cadastrado.\n");
            return;
        }

        decimal totalInvestido = 0;
        decimal totalFinal = 0;

        foreach (var inv in investimentos)
        {
            totalInvestido += inv.ValorInicial;
            totalFinal += inv.CalcularValorFinal();
        }

        decimal lucro = totalFinal - totalInvestido;

        Console.WriteLine($"Total Investido: {totalInvestido:C}");
        Console.WriteLine($"Valor Projetado: {totalFinal:C}");
        Console.WriteLine($"Lucro Projetado: {lucro:C}");

        if (lucro > 0)
            Console.WriteLine("Status: 🟢 Investimentos lucrativos");
        else if (lucro < 0)
            Console.WriteLine("Status: 🔴 Prejuízo");
        else
            Console.WriteLine("Status: ⚪ Sem lucro");

        Console.WriteLine();
    }
}
