using System.Text.Json;
using FinanceApp.Models;

namespace FinanceApp.Data;

public static class RepositorioTransacoes
{
    private static string caminhoArquivo = "transacoes.json";

    public static List<Transacao> Carregar()
    {
        if (!File.Exists(caminhoArquivo))
            return new List<Transacao>();

        string json = File.ReadAllText(caminhoArquivo);

        return JsonSerializer.Deserialize<List<Transacao>>(json)
               ?? new List<Transacao>();
    }

    public static void Salvar(List<Transacao> transacoes)
    {
        string json = JsonSerializer.Serialize(
            transacoes,
            new JsonSerializerOptions { WriteIndented = true }
        );

        File.WriteAllText(caminhoArquivo, json);
    }
}
