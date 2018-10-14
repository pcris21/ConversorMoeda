using Neon.Currency.Exchange.UI.Web.ViewModels;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Neon.Currency.Exchange.UI.Web.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            // /api/currencies
            string url = "http://localhost:54362/api/currencies";
            var client = new HttpClient();

            var response = await client.GetAsync(url);

            response.EnsureSuccessStatusCode();

            var data = await response.Content.ReadAsStringAsync();

            var currencies = JsonConvert.DeserializeObject<IEnumerable<CurrencyViewModel>>(data);

            var vmExchange = new ExchangeViewModel();

            vmExchange.Currencies = new SelectList(currencies, "CurrencyCode", "CurrencyCode");

            TempData["Currencies"] = vmExchange.Currencies;

            TempData.Keep();

            return View(vmExchange);
        }

        [HttpPost]
        public async Task<ActionResult> Index(ExchangeViewModel model)
        {

            // /api/exchange
            string url = $"http://localhost:54362/api/exchange?currency={model.Currency}&amount={model.Amount}";

            var client = new HttpClient();

            var response = await client.GetAsync(url);

            response.EnsureSuccessStatusCode();

            var data = await response.Content.ReadAsStringAsync();

            var vmExchange = JsonConvert.DeserializeObject<ExchangeViewModel>(data);

            ModelState["ValueExchange"].Value = new ValueProviderResult(vmExchange.ValueExchange, "New Value", CultureInfo.CurrentCulture);
            ModelState["CalculatedValue"].Value = new ValueProviderResult(vmExchange.CalculatedValue, "New Value", CultureInfo.CurrentCulture);

            vmExchange.Currencies = (SelectList)TempData["Currencies"];

            TempData.Keep();

            return View(vmExchange);
        }

    }
}