using SeguimientoDeCriptomonedas.Domain.Entities;
using SeguimientoDeCriptomonedas.Domain.Interfaces;
using SeguimientoDeCriptomonedas.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SeguimientoDeCriptomonedas.Domain.DTOs;

namespace SeguimientoDeCriptomonedas.Infrastructure.Repositories
{
    public class FavoriteRepository : IFavoriteRepository
    {
        private readonly AppDbContext _appDbContext;

        public FavoriteRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<FavoriteEntity>> GetFavoriteAsync()
        {
            var response = await _appDbContext.Favorite.ToListAsync();
            return response;
        }

        public async Task<FavoriteEntity> GetFavoriteById(int id)
        {
            var response = await _appDbContext.Favorite.FirstOrDefaultAsync(x => x.Id == id);
            return response;
        }

        public async Task<FavoriteEntity> GetFavoriteByNameAsync(string name)
        {
            var response = await  _appDbContext.Favorite.FirstOrDefaultAsync(x => x.Name == name);
            return response;
        }

        public async Task<FavoriteEntity> PostFavoriteAsync(FavoriteEntity request)
        {
            await _appDbContext.Favorite.AddAsync(request);
            await _appDbContext.SaveChangesAsync();
            return request;
        }

        public async Task DeleteFavoriteAsync(FavoriteEntity request)
        {
            _appDbContext.Favorite.Remove(request);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
