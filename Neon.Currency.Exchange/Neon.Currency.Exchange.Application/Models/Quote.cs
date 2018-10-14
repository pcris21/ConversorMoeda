using System.ComponentModel;

namespace Neon.Currency.Exchange.Application.Models
{
    public class Quote
    {
        [Description("Real")]
        public decimal USDBRL { get; set; }

        [Description("Euro")]
        public decimal USDEUR { get; set; }

        [Description("Dólar Canadense")]
        public decimal USDCAD { get; set; }

        [Description("Dólar Australiano")]
        public decimal USDAUD { get; set; }

        [Description("Libra Esterlina")]
        public decimal USDGBP { get; set; }

        [Description("Iene Japonês")]
        public decimal USDJPY { get; set; }

        [Description("Peso Mexicano")]
        public decimal USDMXN { get; set; }

        [Description("Franco Suiço")]
        public decimal USDCHF { get; set; }

        [Description("Dólar de Hon Kong")]
        public decimal USDHKD { get; set; }

        [Description("Peso Argentino")]
        public decimal USDARS { get; set; }
    }
}
