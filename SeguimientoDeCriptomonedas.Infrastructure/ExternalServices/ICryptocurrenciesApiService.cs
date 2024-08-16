using SeguimientoDeCriptomonedas.Infrastructure.ExternalServices.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeguimientoDeCriptomonedas.Infrastructure.ExternalServices
{
    public interface ICryptocurrenciesApiService
    {
        Task<List<CryptocurrenciesDto>> GetCryptocurrencyData();
        Task<CryptocurrenciesDetailsDto> GetCryptocurrencyDetail(string id);
    }
}
