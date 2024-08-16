using Microsoft.EntityFrameworkCore;
using SeguimientoDeCriptomonedas.Infrastructure.Context;
using SeguimientoDeCriptomonedas.Domain.Interfaces;
using SeguimientoDeCriptomonedas.Infrastructure.Repositories;
using SeguimientoDeCriptomonedas.Service.Services;
using System;
using SeguimientoDeCriptomonedas.Infrastructure.ExternalServices;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Configurar servicios CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IFavoriteRepository, FavoriteRepository>();
builder.Services.AddScoped<IFavoriteService, FavoriteService>();

builder.Services.AddHttpClient<IHttpClient, HttpClientService>();
builder.Services.AddTransient<ICryptocurrenciesApiService, CryptocurrenciesApiService>();

var app = builder.Build();

// Usar CORS
app.UseCors("AllowAll");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
