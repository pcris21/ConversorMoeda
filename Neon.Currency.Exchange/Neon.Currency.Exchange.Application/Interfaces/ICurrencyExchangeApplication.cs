using System.Collections.Generic;
using System.Threading.Tasks;

namespace Neon.Currency.Exchange.Application.Interfaces
{
    public interface ICurrencyExchangeApplication
    {
        IEnumerable<Models.Currency> GetCurrencies();

        Task<Models.CurrencyExchangeResult> GetExchange(string currency, int amount = 1);

    }
}
