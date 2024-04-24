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

builder.Services.AddScoped<IService<Movie>, MovieService>();
builder.Services.AddScoped<IService<Character>, CharacterService>();
builder.Services.AddScoped<IService<Planet>, PlanetService>();
builder.Services.AddScoped<IService<StarShip>, StarShipService>();
builder.Services.AddScoped<IService<Vehicle>, VehicleService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

// Endpoints to Movies
app.MapPost("/movies", async (Movie movie, IService<Movie> _movieService) =>
{
    if (movie == null) TypedResults.BadRequest();
    await _movieService.AddRegister(movie);
    return Results.Created($"{movie.Id}", movie);
})
    .WithName("AddMovie");

app.MapGet("/movies", async (IService<Movie> _movieService) =>
{

    var moviesList = await _movieService.GetRegisters();
    return Results.Ok(moviesList);
})
    .WithName("GetMovies");

app.MapGet("/movies/{id}", async (IService<Movie> _movieService, int id) =>
{

    var movie = await _movieService.GetRegisterById(id);
    if (movie != null) return Results.Ok(movie);
    return Results.NotFound();
})
    .WithName("GetMovieById");

app.MapPut("/movies/{id}", async (IService<Movie> _movieService, int id, Movie movie) =>
{

    var updatedMovie = await _movieService.UpdateRegister(id, movie);
    if (updatedMovie != null) return Results.Ok(updatedMovie);
    return Results.NotFound();
})
    .WithName("UpdateMovies");


app.MapDelete("/movies/{id}", async (IService<Movie> _movieService, int id) =>
{

    var deleteResult = await _movieService.DeleteRegister(id);
    if (deleteResult) return Results.Ok();
    return Results.NotFound();
})
    .WithName("DeleteMovies");

// Endpoints to Character
app.MapPost("/characters", async (Character character, IService<Character> _characterService) =>
{
    if (character == null) TypedResults.BadRequest();
    await _characterService.AddRegister(character);
    return Results.Created($"{character.Id}", character);
})
    .WithName("AddCharacter");

app.MapGet("/characters", async (IService<Character> _characterService) =>
{
    var charactersList = await _characterService.GetRegisters();
    return Results.Ok(charactersList);
})
    .WithName("GetCharacters");

app.MapGet("/characters/{id}", async (IService<Character> _characterService, int id) =>
{
    var character = await _characterService.GetRegisterById(id);
    if (character != null) return Results.Ok(character);
    return Results.NotFound();
})
    .WithName("GetCharacterById");

app.MapPut("/characters/{id}", async (IService<Character> _characterService, int id, Character character) =>
{
    var updatedCharacter = await _characterService.UpdateRegister(id, character);
    if (updatedCharacter != null) return Results.Ok(updatedCharacter);
    return Results.NotFound();
})
    .WithName("UpdateCharacters");

app.MapDelete("/characters/{id}", async (IService<Character> _characterService, int id) =>
{
    var deleteResult = await _characterService.DeleteRegister(id);
    if (deleteResult) return Results.Ok();
    return Results.NotFound();
})
    .WithName("DeleteCharacters");

// Endpoints to Planets
app.MapPost("/planets", async (Planet planet, IService<Planet> _planetService) =>
{
    if (planet == null) TypedResults.BadRequest();
    await _planetService.AddRegister(planet);
    return Results.Created($"{planet.Id}", planet);
})
    .WithName("AddPlanet");

app.MapGet("/planets", async (IService<Planet> _planetService) =>
{
    var planetsList = await _planetService.GetRegisters();
    return Results.Ok(planetsList);
})
    .WithName("GetPlanets");

app.MapGet("/planets/{id}", async (IService<Planet> _planetService, int id) =>
{
    var planet = await _planetService.GetRegisterById(id);
    if (planet != null) return Results.Ok(planet);
    return Results.NotFound();
})
    .WithName("GetPlanetById");

app.MapPut("/planets/{id}", async (IService<Planet> _planetService, int id, Planet planet) =>
{
    var updatedPlanet = await _planetService.UpdateRegister(id, planet);
    if (updatedPlanet != null) return Results.Ok(updatedPlanet);
    return Results.NotFound();
})
    .WithName("UpdatePlanet");

app.MapDelete("/planets/{id}", async (IService<Planet> _planetService, int id) =>
{
    var deleteResult = await _planetService.DeleteRegister(id);
    if (deleteResult) return Results.Ok();
    return Results.NotFound();
})
    .WithName("DeletePlanet");

// Endpoints to StarShip
app.MapPost("/starships", async (StarShip starShip, IService<StarShip> _starShipService) =>
{
    if (starShip == null) TypedResults.BadRequest();
    await _starShipService.AddRegister(starShip);
    return Results.Created($"{starShip.Id}", starShip);
})
    .WithName("AddStarShip");

app.MapGet("/starships", async (IService<StarShip> _starShipService) =>
{
    var starShipsList = await _starShipService.GetRegisters();
    return Results.Ok(starShipsList);
})
    .WithName("GetStarShips");

app.MapGet("/starships/{id}", async (IService<StarShip> _starShipService, int id) =>
{
    var starShip = await _starShipService.GetRegisterById(id);
    if (starShip != null) return Results.Ok(starShip);
    return Results.NotFound();
})
    .WithName("GetStarShipById");

app.MapPut("/starships/{id}", async (IService<StarShip> _starShipService, int id, StarShip starShip) =>
{
    var updatedStarShip = await _starShipService.UpdateRegister(id, starShip);
    if (updatedStarShip != null) return Results.Ok(updatedStarShip);
    return Results.NotFound();
})
    .WithName("UpdateStarShip");

app.MapDelete("/starships/{id}", async (IService<StarShip> _starShipService, int id) =>
{
    var deleteResult = await _starShipService.DeleteRegister(id);
    if (deleteResult) return Results.Ok();
    return Results.NotFound();
})
    .WithName("DeleteStarShip");

// Endpoints to Vehicle
app.MapPost("/vehicles", async (Vehicle vehicle, IService<Vehicle> _vehicleService) =>
{
    if (vehicle == null) TypedResults.BadRequest();
    await _vehicleService.AddRegister(vehicle);
    return Results.Created($"{vehicle.Id}", vehicle);
})
    .WithName("AddVehicle");

app.MapGet("/vehicles", async (IService<Vehicle> _vehicleService) =>
{
    var vehiclesList = await _vehicleService.GetRegisters();
    return Results.Ok(vehiclesList);
})
    .WithName("GetVehicles");

app.MapGet("/vehicles/{id}", async (IService<Vehicle> _vehicleService, int id) =>
{
    var vehicle = await _vehicleService.GetRegisterById(id);
    if (vehicle != null) return Results.Ok(vehicle);
    return Results.NotFound();
})
    .WithName("GetVehicleById");

app.MapPut("/vehicles/{id}", async (IService<Vehicle> _vehicleService, int id, Vehicle vehicle) =>
{
    var updatedVehicle = await _vehicleService.UpdateRegister(id, vehicle);
    if (updatedVehicle != null) return Results.Ok(updatedVehicle);
    return Results.NotFound();
})
    .WithName("UpdateVehicle");

app.MapDelete("/vehicles/{id}", async (IService<Vehicle> _vehicleService, int id) =>
{
    var deleteResult = await _vehicleService.DeleteRegister(id);
    if (deleteResult) return Results.Ok();
    return Results.NotFound();
})
    .WithName("DeleteVehicle");


//todo criar dtos, resolver referencia ciclica, tratar errors do crud, implementar crud para outros models, seed da db

app.Run();
