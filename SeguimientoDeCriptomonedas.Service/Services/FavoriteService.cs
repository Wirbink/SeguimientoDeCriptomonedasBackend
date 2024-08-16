using SeguimientoDeCriptomonedas.Domain.DTOs;
using SeguimientoDeCriptomonedas.Domain.Entities;
using SeguimientoDeCriptomonedas.Domain.Interfaces;
using SeguimientoDeCriptomonedas.Service.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeguimientoDeCriptomonedas.Service.Services
{
    public class FavoriteService : IFavoriteService
    {
        private readonly IFavoriteRepository _favoriteRepository;

        public FavoriteService(IFavoriteRepository favoriteRepository)
        {
            _favoriteRepository = favoriteRepository;
        }

        public async Task DeleteFavoriteAsync(int id)
        {
            try
            {
                var favorite = await _favoriteRepository.GetFavoriteById(id);

                if(favorite == null)
                {
                    throw new FavoriteNotFoundById(id);
                }

                await _favoriteRepository.DeleteFavoriteAsync(favorite);
            } 
            catch (FavoriteNotFoundException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while retrieving cryptocurrencies.");
            }
        }

        public async Task<List<FavoriteResponseDto>> GetFavoritesAsync()
        {
            try
            {
                var favorites = await _favoriteRepository.GetFavoriteAsync();

                return favorites.Select(f => new FavoriteResponseDto
                {
                    Id = f.Id,
                    Name = f.Name,
                    Symbol = f.Symbol,
                    Image = f.Image
                }).ToList();

            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while retrieving cryptocurrencies.");
            }

        }

        public async Task<FavoriteResponseDto> GetFavoriteByIdAsync(int id)
        {
            try
            {
                var favorite = await _favoriteRepository.GetFavoriteById(id);

                if(favorite == null)
                {
                    throw new FavoriteNotFoundById(id);
                }

                return new FavoriteResponseDto
                {
                    Id = favorite.Id,
                    Name = favorite.Name,
                    Symbol = favorite.Symbol,
                    Image = favorite.Image
                };
            }
            catch (FavoriteNotFoundById)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while get a favorite cryptocurrency.", ex);
            }
        }

        public async Task<FavoriteResponseDto> PostFavoriteAsync(AddFavoriteRequestDto request)
        {
            try
            {
                var existingFavorite = await _favoriteRepository.GetFavoriteByNameAsync(request.Name);

                if (existingFavorite != null)
                {
                    throw new FavoriteAlreadyExistsException(request.Name);
                }

                var favoriteEntity = new FavoriteEntity
                {
                    Name = request.Name,
                    Symbol = request.Symbol,
                    Image = request.Image
                };

                var createdFavorite = await _favoriteRepository.PostFavoriteAsync(favoriteEntity);

                return new FavoriteResponseDto
                {
                    Id = createdFavorite.Id,
                    Name = createdFavorite.Name,
                    Symbol = createdFavorite.Symbol,
                    Image = createdFavorite.Image
                };
            }
            catch (FavoriteAlreadyExistsException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while creating a favorite cryptocurrency.", ex);
            }
        }
    }
}
