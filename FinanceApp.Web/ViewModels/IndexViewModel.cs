using FinanceApp.Web.Models;
using System.Collections.Generic;

namespace FinanceApp.Web.ViewModels
{
    public class IndexViewModel
    {
        public List<Transacao> Transacoes { get; set; } = new();

        public decimal TotalEntradas { get; set; }

        public decimal TotalSaidas { get; set; }

        public decimal Saldo => TotalEntradas - TotalSaidas;
    }
}