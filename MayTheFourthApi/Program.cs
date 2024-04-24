using MayTheFourthApi.Data;
using MayTheFourthApi.Models;
using MayTheFourthApi.Routes;
using MayTheFourthApi.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(option =>
{
    option.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IService<Movie>, MovieService>();
builder.Services.AddScoped<IService<Character>, CharacterService>();
builder.Services.AddScoped<IService<Planet>, PlanetService>();
builder.Services.AddScoped<IService<StarShip>, StarShipService>();
builder.Services.AddScoped<IService<Vehicle>, VehicleService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapMovieRoutes();
app.MapCharacterRoutes();
app.MapPlanetRoutes();
app.MapStarSchipRoutes();
app.MapVehicleRoutes();

app.Run();

/*
- TO DO
    - [] Criar dtos;
    - [] Resolver referencia ciclica;
    - [] Tratar errors do crud;
    - [] Implementar crud para outros models;
    - [] Seed da db;
*/

