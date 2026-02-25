using System.Text.Json;
using FinanceApp.Models;

namespace FinanceApp.Data;

public static class RepositorioInvestimentos
{
    private static string caminho = "investimentos.json";

    public static List<Investimento> Carregar()
    {
        if (!File.Exists(caminho))
            return new List<Investimento>();

        string json = File.ReadAllText(caminho);
        return JsonSerializer.Deserialize<List<Investimento>>(json) ?? new List<Investimento>();
    }

    public static void Salvar(List<Investimento> investimentos)
    {
        string json = JsonSerializer.Serialize(investimentos, new JsonSerializerOptions
        {
            WriteIndented = true
        });

        File.WriteAllText(caminho, json);
    }
}
