using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeguimientoDeCriptomonedas.Infrastructure.ExternalServices.DTOs
{
    public class MarketData
    {
        public CurrentPrice current_price { get; set; }
        public double? market_cap_fdv_ratio { get; set; }
        public MarketCap market_cap { get; set; }
        public TotalVolume total_volume { get; set; }
        public double price_change_24h { get; set; }
        public double price_change_percentage_24h { get; set; }
        public double price_change_percentage_7d { get; set; }
        public double price_change_percentage_14d { get; set; }
        public double price_change_percentage_30d { get; set; }
        public double price_change_percentage_60d { get; set; }
        public double price_change_percentage_200d { get; set; }
        public double price_change_percentage_1y { get; set; }
        public DateTime last_updated { get; set; }
    }

    public class CurrentPrice
    {
        public double usd { get; set; }
    }

    public class MarketCap
    {
        public double usd { get; set; }
    }

    public class TotalVolume
    {
        public double usd { get; set; }
    }


    public class CryptocurrenciesDetailsDto
    {
        public string id { get; set; }
        public string name { get; set; }
        public string symbol { get; set; }
        public MarketData market_data { get; set; }
    }

}
