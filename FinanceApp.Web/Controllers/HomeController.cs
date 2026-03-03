using Microsoft.AspNetCore.Mvc;
using FinanceApp.Web.Models;

namespace FinanceApp.Web.Controllers;

public class HomeController : Controller
{
    private static List<Transacao> transacoes = new List<Transacao>();

    public IActionResult Index()
    {
        return View(transacoes);
    }

    [HttpPost]
    public IActionResult Adicionar(string tipo, decimal valor, string descricao)
    {
        var nova = new Transacao(tipo, valor, descricao);
        transacoes.Add(nova);

        return RedirectToAction("Index");
    }
}