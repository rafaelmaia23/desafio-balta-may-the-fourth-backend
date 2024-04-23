using MayTheFourthApi.Data;
using MayTheFourthApi.Models;
using MayTheFourthApi.Services;
using MayTheFourthApi.Services.IServices;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(option =>
{
    option.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IMovieService, MovieService>();
builder.Services.AddScoped<ICharacterService, CharacterService>();
builder.Services.AddScoped<IPlanetService, PlanetService>();
builder.Services.AddScoped<IStarShipService, StarShipService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapPost("/movies", async (Movie movie, IMovieService _movieService) =>
{
    if(movie == null) TypedResults.BadRequest();
    await _movieService.AddMovie(movie);
    return Results.Created($"{movie.Id}", movie);
})
    .WithName("AddMovie");

app.MapGet("/movies/{id}", async (IMovieService _movieService, int id) =>
{
    
    var movie = await _movieService.GetMovieById(id);
    if(movie != null) return Results.Ok(movie);
    else return Results.NotFound();
})
    .WithName("GetMovieById");

app.MapGet("/movies", async (IMovieService _movieService) =>
{

    var moviesList = await _movieService.GetMovies();
    return Results.Ok(moviesList);
})
    .WithName("GetMovies");

app.MapDelete("/movies/{id}", async (IMovieService _movieService, int id) =>
{

    var deleteResult = await _movieService.DeleteMovie(id);
    if (deleteResult) return Results.Ok();
    else return Results.NotFound();
})
    .WithName("DeleteMovies");

app.MapPut("/movies/{id}", async (IMovieService _movieService, int id, Movie movie) =>
{

    var updatedMovie = await _movieService.UpdateMovie(id, movie);
    if (updatedMovie != null) return Results.Ok(updatedMovie);
    else return Results.NotFound();
})
    .WithName("UpdateMovies");

// Endpoints to Character
app.MapPost("/characters", async (Character character, ICharacterService _characterService) =>
{
    if (character == null) TypedResults.BadRequest();
    await _characterService.AddCharacter(character);
    return Results.Created($"{character.Id}", character);
})
    .WithName("AddCharacter");

app.MapGet("/characters/{id}", async (ICharacterService _characterService, int id) =>
{
    var character = await _characterService.GetCharacterById(id);
    if (character != null) return Results.Ok(character);
    else return Results.NotFound();
})
    .WithName("GetCharacterById");

app.MapGet("/characters", async (ICharacterService _characterService) =>
{
    var charactersList = await _characterService.GetCharacters();
    return Results.Ok(charactersList);
})
    .WithName("GetCharacters");

app.MapDelete("/characters/{id}", async (ICharacterService _characterService, int id) =>
{
    var deleteResult = await _characterService.DeleteCharacter(id);
    if (deleteResult) return Results.Ok();
    else return Results.NotFound();
})
    .WithName("DeleteCharacters");

app.MapPut("/characters/{id}", async (ICharacterService _characterService, int id, Character character) =>
{
    var updatedCharacter = await _characterService.UpdateCharacter(id, character);
    if (updatedCharacter != null) return Results.Ok(updatedCharacter);
    else return Results.NotFound();
})
    .WithName("UpdateCharacters");

// Endpoints to Planets
app.MapPost("/planets", async (Planet planet, IPlanetService _planetService) =>
{
    if (planet == null) TypedResults.BadRequest();
    await _planetService.AddPlanet(planet);
    return Results.Created($"{planet.Id}", planet);
})
    .WithName("AddPlanet");

app.MapGet("/planets/{id}", async (IPlanetService _planetService, int id) =>
{
    var planet = await _planetService.GetPlanetById(id);
    if (planet != null) return Results.Ok(planet);
    else return Results.NotFound();
})
    .WithName("GetPlanetById");

app.MapGet("/planets", async (IPlanetService _planetService) =>
{
    var planetsList = await _planetService.GetPlanets();
    return Results.Ok(planetsList);
})
    .WithName("GetPlanets");

app.MapDelete("/planets/{id}", async (IPlanetService _planetService, int id) =>
{
    var deleteResult = await _planetService.DeletePlanet(id);
    if (deleteResult) return Results.Ok();
    else return Results.NotFound();
})
    .WithName("DeletePlanet");

app.MapPut("/planets/{id}", async (IPlanetService _planetService, int id, Planet planet) =>
{
    var updatedPlanet = await _planetService.UpdatePlanet(id, planet);
    if (updatedPlanet != null) return Results.Ok(updatedPlanet);
    else return Results.NotFound();
})
    .WithName("UpdatePlanet");

// Endpoints to StarShip
app.MapPost("/starships", async (StarShip starShip, IStarShipService _starShipService) =>
{
    if (starShip == null) TypedResults.BadRequest();
    await _starShipService.AddStarShip(starShip);
    return Results.Created($"{starShip.Id}", starShip);
})
    .WithName("AddStarShip");

app.MapGet("/starships/{id}", async (IStarShipService _starShipService, int id) =>
{
    var starShip = await _starShipService.GetStarShipById(id);
    if (starShip != null) return Results.Ok(starShip);
    else return Results.NotFound();
})
    .WithName("GetStarShipById");

app.MapGet("/starships", async (IStarShipService _starShipService) =>
{
    var starShipsList = await _starShipService.GetStarShips();
    return Results.Ok(starShipsList);
})
    .WithName("GetStarShips");

app.MapDelete("/starships/{id}", async (IStarShipService _starShipService, int id) =>
{
    var deleteResult = await _starShipService.DeleteStarShip(id);
    if (deleteResult) return Results.Ok();
    else return Results.NotFound();
})
    .WithName("DeleteStarShip");

app.MapPut("/starships/{id}", async (IStarShipService _starShipService, int id, StarShip starShip) =>
{
    var updatedStarShip = await _starShipService.UpdateStarShip(id, starShip);
    if (updatedStarShip != null) return Results.Ok(updatedStarShip);
    else return Results.NotFound();
})
    .WithName("UpdateStarShip");

//todo criar dtos, resolver referencia ciclica, tratar errors do crud, implementar crud para outros models, seed da db

app.Run();
