using SeguimientoDeCriptomonedas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeguimientoDeCriptomonedas.Domain.Interfaces
{
    public interface IFavoriteRepository
    {
       Task<List<FavoriteEntity>> GetFavoriteAsync();
        Task<FavoriteEntity> GetFavoriteById(int id);
       Task<FavoriteEntity> GetFavoriteByNameAsync(string name);
       Task<FavoriteEntity> PostFavoriteAsync(FavoriteEntity request);
       Task DeleteFavoriteAsync (FavoriteEntity request);
    }
}
