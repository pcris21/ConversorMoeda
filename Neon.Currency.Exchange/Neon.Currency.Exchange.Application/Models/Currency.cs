using System.Collections.Generic;

namespace Neon.Currency.Exchange.Application.Models
{
    public class Currency
    {
        public string CurrencyCode { get; set; }

        public List<Currency> GetCurrenciesList()
        {
            var currencies = new List<Currency>
            {
                new Currency {CurrencyCode = "BRL"},
                new Currency {CurrencyCode = "EUR"},
                new Currency {CurrencyCode = "AUD"},
                new Currency {CurrencyCode = "CAD"},
                new Currency {CurrencyCode = "GBP"},
                new Currency {CurrencyCode = "JPY"},
                new Currency {CurrencyCode = "CHF"},
                new Currency {CurrencyCode = "MXN"},
                new Currency {CurrencyCode = "HKD"},
                new Currency {CurrencyCode = "ARS"}
            };

            return currencies;
        }

    }
}
