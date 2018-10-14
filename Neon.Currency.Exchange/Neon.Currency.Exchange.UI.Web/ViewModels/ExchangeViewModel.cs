using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Neon.Currency.Exchange.UI.Web.ViewModels
{
    public class ExchangeViewModel
    {
        [Display(Name = "Valor do Câmbio")]
        public decimal ValueExchange { get; set; }

        [Display(Name = "Valor Calculado")]
        public decimal CalculatedValue { get; set; }

        [Display(Name = "Informe a quantidade")]
        public int Amount { get; set; }
       
        [Display(Name = "Selecione a moeda")]
        public SelectList Currencies { get; set; }

        public string Currency { get; set; }

    }
}