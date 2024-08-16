using Microsoft.AspNetCore.Mvc;
using SeguimientoDeCriptomonedas.Domain.DTOs;
using SeguimientoDeCriptomonedas.Domain.Entities;
using SeguimientoDeCriptomonedas.Domain.Interfaces;
using SeguimientoDeCriptomonedas.Service.Common;
using SeguimientoDeCriptomonedas.Service.Exceptions;
using Swashbuckle.AspNetCore.Annotations;

namespace SeguimientoDeCriptomonedas.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FavoritesController : ControllerBase
    {
        private readonly IFavoriteService _favoriteService;

        public FavoritesController(IFavoriteService favoriteService)
        {
            _favoriteService = favoriteService;
        }

        [HttpGet]
        [SwaggerResponse(200)]
        public async Task<IActionResult> GetFavorites()
        {
            try
            {
                var favorites = await _favoriteService.GetFavoritesAsync();
                return Ok(ApiResponseHelper.CreateSuccessResponse(favorites, "Favorite cryptocurrencies retrieved successfully."));
            }
            catch (ApplicationException ex)
            {
                return StatusCode(500, ApiResponseHelper.CreateErrorResponse("INTERNAL_SERVER_ERROR", ex.Message, "An error occurred while processing your request."));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponseHelper.CreateErrorResponse("UNEXPECTED_ERROR", ex.Message, "An unexpected error occurred."));
            }
        }

        [HttpPost]
        [SwaggerResponse(200)]
        public async Task<IActionResult> PostFavoriteAsync([FromBody] AddFavoriteRequestDto request)
        {
            try
            {
                var favorite = await _favoriteService.PostFavoriteAsync(request);
                var response = ApiResponseHelper.CreateSuccessResponse(favorite, "Favorite cryptocurrency created successfully.");
                return CreatedAtAction(nameof(GetFavorites), new { id = favorite.Id }, response);
            }
            catch (FavoriteAlreadyExistsException ex)
            {
                return Conflict(ApiResponseHelper.CreateErrorResponse("FAVORITE_ALREADY_EXISTS", ex.Message, "A favorite with the same name already exists."));
            }
            catch (ApplicationException ex)
            {
                return StatusCode(500, ApiResponseHelper.CreateErrorResponse("INTERNAL_SERVER_ERROR", ex.Message, "An error occurred while processing your request."));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponseHelper.CreateErrorResponse("UNEXPECTED_ERROR", ex.Message, "An unexpected error occurred."));
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFavoriteAsync(int id)
        {
            try
            {
                await _favoriteService.DeleteFavoriteAsync(id);
                return Ok(ApiResponseHelper.CreateSuccessResponse<object>(null, "Favorite cryptocurrency deleted successfully."));
            }
            catch (FavoriteNotFoundException ex)
            {
                return NotFound(ApiResponseHelper.CreateErrorResponse("FAVORITE_NOT_FOUND", ex.Message, "The requested favorite could not be found."));
            }
            catch (ApplicationException ex)
            {
                return StatusCode(500, ApiResponseHelper.CreateErrorResponse("INTERNAL_SERVER_ERROR", ex.Message, "An error occurred while processing your request."));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponseHelper.CreateErrorResponse("UNEXPECTED_ERROR", ex.Message, "An unexpected error occurred."));
            }
        }
    }
}
