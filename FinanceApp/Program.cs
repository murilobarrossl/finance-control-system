using FinanceApp.Data;
using FinanceApp.Models;
using FinanceApp.Services;

// ================= INICIALIZAÇÃO =================

bool executando = true;

List<Transacao> transacoes = RepositorioTransacoes.Carregar();
List<Investimento> investimentos = RepositorioInvestimentos.Carregar();

while (executando)
{
    MostrarMenu();
    string? opcao = Console.ReadLine();
    executando = ProcessarOpcao(opcao, transacoes, investimentos);
}

Console.WriteLine("Programa encerrado.");


// ================= MENU =================

static void MostrarMenu()
{
    Console.Clear();
    Console.WriteLine("=================================");
    Console.WriteLine("        FINCONTROL");
    Console.WriteLine("=================================");
    Console.WriteLine("1 - Cadastrar Receita");
    Console.WriteLine("2 - Cadastrar Despesa");
    Console.WriteLine("3 - Cadastrar Investimento");
    Console.WriteLine("4 - Listar Transações");
    Console.WriteLine("5 - Ver Saldo");
    Console.WriteLine("6 - Listar Investimentos");
    Console.WriteLine("7 - Relatório Financeiro");
    Console.WriteLine("0 - Sair");
    Console.WriteLine("=================================");
    Console.Write("Escolha uma opção: ");
}



// ================= CONTROLE =================

static bool ProcessarOpcao(
    string? opcao,
    List<Transacao> transacoes,
    List<Investimento> investimentos)
{
    switch (opcao)
    {
        case "1":
            CadastrarReceita(transacoes);
            RepositorioTransacoes.Salvar(transacoes);
            break;

        case "2":
            CadastrarDespesa(transacoes);
            RepositorioTransacoes.Salvar(transacoes);
            break;

        case "3":
            CadastrarInvestimento(investimentos);
            RepositorioInvestimentos.Salvar(investimentos);
            break;

        case "4":
            ListarTransacoes(transacoes);
            break;

        case "5":
            MostrarSaldo(transacoes);
            break;

        case "6":
            ListarInvestimentos(investimentos);
            break;
        
        case "7":
            MostrarRelatorio(transacoes, investimentos);
            break;

        case "0":
            Console.WriteLine("Encerrando o Fincontrol...");
            Console.ReadKey();
            return false;

        default:
            Console.WriteLine("Opção inválida.");
            Console.ReadKey();
            break;
    }

    return true;
}


// ================= TRANSAÇÕES =================

static void CadastrarReceita(List<Transacao> transacoes)
{
    Console.Clear();
    Console.WriteLine("=== CADASTRAR RECEITA ===");

    Console.Write("Valor: ");
    decimal valor = decimal.Parse(Console.ReadLine()!);

    Console.Write("Descrição: ");
    string descricao = Console.ReadLine()!;

    transacoes.Add(new Transacao("Receita", valor, descricao));

    Console.WriteLine("Receita cadastrada com sucesso!");
    Console.ReadKey();
}

static void CadastrarDespesa(List<Transacao> transacoes)
{
    Console.Clear();
    Console.WriteLine("=== CADASTRAR DESPESA ===");

    Console.Write("Valor: ");
    decimal valor = decimal.Parse(Console.ReadLine()!);

    Console.Write("Descrição: ");
    string descricao = Console.ReadLine()!;

    transacoes.Add(new Transacao("Despesa", valor, descricao));

    Console.WriteLine("Despesa cadastrada com sucesso!");
    Console.ReadKey();
}

static void ListarTransacoes(List<Transacao> transacoes)
{
    Console.Clear();
    Console.WriteLine("=== TRANSAÇÕES ===");

    if (transacoes.Count == 0)
    {
        Console.WriteLine("Nenhuma transação cadastrada.");
    }
    else
    {
        foreach (var t in transacoes)
        {
            Console.WriteLine(t);
        }
    }

    Console.ReadKey();
}

static void MostrarSaldo(List<Transacao> transacoes)
{
    decimal saldo = 0;

    foreach (var t in transacoes)
    {
        if (t.Tipo == "Receita")
            saldo += t.Valor;
        else if (t.Tipo == "Despesa")
            saldo -= t.Valor;
    }

    Console.Clear();
    Console.WriteLine("=== SALDO ATUAL ===");
    Console.WriteLine($"Saldo: {saldo:C}");

    Console.ReadKey();
}


// ================= INVESTIMENTOS =================

static void CadastrarInvestimento(List<Investimento> investimentos)
{
    Console.Clear();
    Console.WriteLine("=== CADASTRAR INVESTIMENTO ===");

    Console.Write("Descrição: ");
    string descricao = Console.ReadLine()!;

    Console.Write("Valor inicial: ");
    decimal valorInicial = decimal.Parse(Console.ReadLine()!);

    Console.Write("Taxa mensal (%): ");
    decimal taxaMensal = decimal.Parse(Console.ReadLine()!);

    Console.Write("Meses: ");
    int meses = int.Parse(Console.ReadLine()!);

    investimentos.Add(
        new Investimento(descricao, valorInicial, taxaMensal, meses)
    );

    Console.WriteLine("Investimento cadastrado com sucesso!");
    Console.ReadKey();
}

static void ListarInvestimentos(List<Investimento> investimentos)
{
    Console.Clear();
    Console.WriteLine("=== INVESTIMENTOS ===");

    if (investimentos.Count == 0)
    {
        Console.WriteLine("Nenhum investimento cadastrado.");
    }
    else
    {
        foreach (var inv in investimentos)
        {
            Console.WriteLine(inv.GerarResumo());
        }
    }

    Console.ReadKey();
}
static void MostrarRelatorio(
    List<Transacao> transacoes,
    List<Investimento> investimentos)
{
    Console.Clear();
    Console.WriteLine("=== RELATÓRIO FINANCEIRO ===");

    var relatorio = new RelatorioFinanceiro(transacoes, investimentos);

    Console.WriteLine($"Total de Receitas: {relatorio.TotalReceitas:C}");
    Console.WriteLine($"Total de Despesas: {relatorio.TotalDespesas:C}");
    Console.WriteLine($"Saldo Atual: {relatorio.Saldo:C}");
    Console.WriteLine();
    Console.WriteLine($"Total Investido: {relatorio.TotalInvestido:C}");
    Console.WriteLine($"Valor Previsto dos Investimentos: {relatorio.TotalPrevistoInvestimentos:C}");

    Console.ReadKey();
}
