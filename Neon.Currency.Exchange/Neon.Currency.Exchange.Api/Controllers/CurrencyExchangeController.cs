using Microsoft.AspNetCore.Mvc;
using Neon.Currency.Exchange.Application.Interfaces;
using System;
using System.Threading.Tasks;

namespace Neon.Currency.Exchange.Api.Controllers
{
    [Produces("application/json")]
    [Route("/api")]
    [ApiController]
    public class CurrencyExchangeController : ControllerBase
    {
        private readonly ICurrencyExchangeApplication _currencyExchangeApplication;

        public CurrencyExchangeController(ICurrencyExchangeApplication currencyExchangeApplication)
        {
            _currencyExchangeApplication = currencyExchangeApplication;
        }

        [HttpGet]
        [Route("/api/currencies")]
        public IActionResult GetCurrencies()
        {
            try
            {
                var result = _currencyExchangeApplication.GetCurrencies();

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message); ;
            }

        }

        [HttpGet]
        [Route("/api/exchange")]
        public async Task<IActionResult> GetExchange(string currency, int amount = 1)
        {
            try
            {
                var result = await _currencyExchangeApplication.GetExchange(currency, amount);

                return Ok(result);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}