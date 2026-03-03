using Microsoft.AspNetCore.Mvc;
using FinanceApp.Web.Models;
using FinanceApp.Web.ViewModels;
using System.Linq;

namespace FinanceApp.Web.Controllers;

public class HomeController : Controller
{
    private static List<Transacao> transacoes = new();

    public IActionResult Index()
    {
        var viewModel = new IndexViewModel
        {
            Transacoes = transacoes,
            TotalEntradas = transacoes
                .Where(t => t.Tipo == TipoTransacao.Entrada)
                .Sum(t => t.Valor),

            TotalSaidas = transacoes
                .Where(t => t.Tipo == TipoTransacao.Saida)
                .Sum(t => t.Valor)
        };

        return View(viewModel);
    }

    [HttpPost]
    public IActionResult Adicionar(string tipo, decimal valor, string descricao)
    {
        if (Enum.TryParse<TipoTransacao>(tipo, out var tipoConvertido))
        {
            var nova = new Transacao(tipoConvertido, valor, descricao);
            transacoes.Add(nova);
        }

        return RedirectToAction("Index");
    }
}