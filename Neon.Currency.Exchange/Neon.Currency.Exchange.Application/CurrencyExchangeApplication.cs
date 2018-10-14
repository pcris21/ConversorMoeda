using Neon.Currency.Exchange.Application.Interfaces;
using Neon.Currency.Exchange.Application.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Neon.Currency.Exchange.Application
{
    public class CurrencyExchangeApplication : ICurrencyExchangeApplication
    {
       
        public IEnumerable<Models.Currency> GetCurrencies()
        {
            var currencies = new Models.Currency().GetCurrenciesList();

            return currencies.AsEnumerable();
        }

        public async Task<CurrencyExchangeResult> GetExchange(string currency, int amount = 1)
        {
            var result = await RequestExchange(currency, amount);

            var exchangeResult = new CurrencyExchangeResult();

            exchangeResult.ValueExchange = GetValueExchange(result.Quotes);

            if (amount > 1)
            {
               exchangeResult.CalculatedValue = exchangeResult.ValueExchange * amount;
            }
            
            return exchangeResult;
        }

        public async Task<CurrencyExchange> RequestExchange(string currency, int amount = 1)
        {
            string url = $"http://www.apilayer.net/api/live?access_key=20d5616715b016685b1d18ac4aec79c6&format=1&currencies={currency}";

            var client = new HttpClient();

            var response = await client.GetAsync(url);

            response.EnsureSuccessStatusCode();

            var data = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<CurrencyExchange>(data);

            return result;
        }
        
        public decimal GetValueExchange(Quote quote)
        {
            decimal value = decimal.Zero;

            switch (quote)
            {
                case Quote q when (q.USDBRL != decimal.Zero):
                    value = q.USDBRL;                   
                    break;

                case Quote q when (q.USDEUR != decimal.Zero):
                    value = q.USDEUR;
                    break;

                case Quote q when (q.USDCAD != decimal.Zero):
                    value = q.USDCAD;
                    break;

                case Quote q when (q.USDAUD != decimal.Zero):
                    value = q.USDAUD;
                    break;

                case Quote q when (q.USDGBP != decimal.Zero):
                    value = q.USDGBP;
                    break;

                case Quote q when (q.USDJPY != decimal.Zero):
                    value = q.USDJPY;
                    break;

                case Quote q when (q.USDMXN != decimal.Zero):
                    value = q.USDMXN;
                    break;

                case Quote q when (q.USDCHF != decimal.Zero):
                    value = q.USDCHF;
                    break;

                case Quote q when (q.USDHKD != decimal.Zero):
                    value = q.USDHKD;
                    break;

                case Quote q when (q.USDARS != decimal.Zero):
                    value = q.USDARS;
                    break;
            }
            return value;
        }

    }
}
