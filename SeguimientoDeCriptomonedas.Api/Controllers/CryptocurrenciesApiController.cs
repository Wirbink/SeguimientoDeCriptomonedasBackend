using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SeguimientoDeCriptomonedas.Infrastructure.ExternalServices;
using SeguimientoDeCriptomonedas.Service.Common;

namespace SeguimientoDeCriptomonedas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CryptocurrenciesApiController : ControllerBase
    {
        private readonly ICryptocurrenciesApiService _cryptocurrenciesService;

        public CryptocurrenciesApiController(ICryptocurrenciesApiService cryptocurrenciesService)
        {
            _cryptocurrenciesService = cryptocurrenciesService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCryptocurrency()
        {
            try
            {
                var data = await _cryptocurrenciesService.GetCryptocurrencyData();
                return Ok(ApiResponseHelper.CreateSuccessResponse(data, "Cryptocurrencies retrieved successfully."));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponseHelper.CreateErrorResponse("UNEXPECTED_ERROR", ex.Message, "An unexpected error occurred."));
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCryptocurrencyDetail(string id)
        {
            try
            {
                var data = await _cryptocurrenciesService.GetCryptocurrencyDetail(id);
                return Ok(ApiResponseHelper.CreateSuccessResponse(data, "Cryptocurrency retrieved successfully."));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponseHelper.CreateErrorResponse("UNEXPECTED_ERROR", ex.Message, "An unexpected error occurred."));
            }
        }
    }
}
