using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeguimientoDeCriptomonedas.Infrastructure.ExternalServices.DTOs
{
    public class CryptocurrenciesDto
    {
        public string Id { get; set; }
        public string Symbol { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public decimal Current_price { get; set; }
        public decimal Market_cap { get; set; }
        public int Market_cap_rank { get; set; }
        public decimal Total_volume { get; set; }
        public decimal Price_change_24h { get; set; }
        public decimal Price_change_percentage_24h { get; set; }
    }
}
