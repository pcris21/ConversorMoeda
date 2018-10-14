namespace Neon.Currency.Exchange.Application.Models
{
    public class CurrencyExchange
    {

        public bool Success { get; set; }
        public long Timestamp { get; set; }
        public string Source { get; set; }
        public Quote Quotes { get; set; }
    }
}
