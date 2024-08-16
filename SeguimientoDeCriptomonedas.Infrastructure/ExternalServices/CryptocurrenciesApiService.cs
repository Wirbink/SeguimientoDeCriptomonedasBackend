using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using SeguimientoDeCriptomonedas.Infrastructure.ExternalServices.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SeguimientoDeCriptomonedas.Infrastructure.ExternalServices
{
    public class CryptocurrenciesApiService : ICryptocurrenciesApiService
    {
        private readonly IHttpClient _httpClient;

        public CryptocurrenciesApiService(IHttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<CryptocurrenciesDto>> GetCryptocurrencyData()
        {
            var url = "https://api.coingecko.com/api/v3/coins/markets?vs_currency=usd&order=market_cap_desc&per_page=10&page=1";
            var response = await _httpClient.GetAsync(url);
            return JsonConvert.DeserializeObject<List<CryptocurrenciesDto>>(response);
        }

        public async Task<CryptocurrenciesDetailsDto> GetCryptocurrencyDetail(string id)
        {
            var url = $"https://api.coingecko.com/api/v3/coins/{id}?localization=false&tickers=false&market_data=true&community_data=false&developer_data=false";
            var jsonResponse = await _httpClient.GetAsync(url);  // Usa el servicio HttpClientService para obtener la respuesta
            return JsonConvert.DeserializeObject<CryptocurrenciesDetailsDto>(jsonResponse);  // Deserializa el JSON en el DTO
        }
    }
}
