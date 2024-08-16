using SeguimientoDeCriptomonedas.Domain.DTOs;
using SeguimientoDeCriptomonedas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeguimientoDeCriptomonedas.Domain.Interfaces
{
    public interface IFavoriteService
    {
        Task<List<FavoriteResponseDto>> GetFavoritesAsync();
        Task<FavoriteResponseDto> GetFavoriteByIdAsync(int id);
        Task<FavoriteResponseDto> PostFavoriteAsync(AddFavoriteRequestDto request);
        Task DeleteFavoriteAsync(int id);
    }
}
