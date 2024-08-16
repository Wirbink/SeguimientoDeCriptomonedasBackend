
using Microsoft.EntityFrameworkCore;
using SeguimientoDeCriptomonedas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeguimientoDeCriptomonedas.Infrastructure.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<FavoriteEntity> Favorite { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
