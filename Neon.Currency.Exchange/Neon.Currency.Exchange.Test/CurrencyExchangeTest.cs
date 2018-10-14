using Neon.Currency.Exchange.Application;
using Neon.Currency.Exchange.Application.Models;
using System.Linq;
using Xunit;

namespace Neon.Currency.Exchange.Test
{
    public class CurrencyExchangeTest
    {
        [Fact]
        public void Get_Currencies_Sucess()
        {
            var currencyExchangeApplication = new CurrencyExchangeApplication();

            var result = currencyExchangeApplication.GetCurrencies();

            Assert.NotEmpty(result);
            Assert.NotNull(result);
            Assert.Equal(10, result.Count());
        }

        [Fact]
        public void Request_Exchange_Sucess()
        {
            var currencyExchangeApplication = new CurrencyExchangeApplication();

            string currency = "EUR";

            int amount = 10;

            var result = currencyExchangeApplication.RequestExchange(currency, amount);

            Assert.NotNull(result);
            Assert.True(result.Result.Success);
            Assert.Equal("USD", result.Result.Source);
            Assert.NotNull(result.Result.Quotes);
        }

        [Fact]
        public void Get_Exchange_Amount_Equal_1_Sucess()
        {
            var currencyExchangeApplication = new CurrencyExchangeApplication();

            string currency = "EUR";
            
            var result = currencyExchangeApplication.GetExchange(currency);

            Assert.NotNull(result);
            Assert.Equal(decimal.Zero, result.Result.CalculatedValue);            
            Assert.NotEqual(decimal.Zero, result.Result.ValueExchange);
        }

        [Fact]
        public void Get_Exchange_Amount_Not_Equal_1_Sucess()
        {
            var currencyExchangeApplication = new CurrencyExchangeApplication();

            string currency = "EUR";
            int amount = 100;

            var result = currencyExchangeApplication.GetExchange(currency, amount);

            Assert.NotNull(result);
            Assert.NotEqual(decimal.Zero, result.Result.CalculatedValue);
            Assert.NotEqual(decimal.Zero, result.Result.ValueExchange);
        }

        [Fact]
        public void GetValueExchange_Sucesso()
        {
            var currencyExchangeApplication = new CurrencyExchangeApplication();
            var quote = new Quote();
            quote.USDCAD = 2.46946M;

            var result = currencyExchangeApplication.GetValueExchange(quote);

            Assert.Equal(quote.USDCAD, result);
        }
    }
}
