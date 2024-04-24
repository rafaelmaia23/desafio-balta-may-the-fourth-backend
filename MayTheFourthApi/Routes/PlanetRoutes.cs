using MayTheFourthApi.Models;
using MayTheFourthApi.Services;

namespace MayTheFourthApi.Routes
{
    public static class PlanetRoutes
    {
        public static void MapPlanetRoutes(this IEndpointRouteBuilder endpoints)
        {
            endpoints.MapPost("/planets", async (Planet planet, IService<Planet> _planetService) =>
            {
                if (planet == null) TypedResults.BadRequest();
                await _planetService.AddRegister(planet);
                return Results.Created($"{planet.Id}", planet);
            }).WithName("AddPlanet");

            endpoints.MapGet("/planets", async (IService<Planet> _planetService) =>
            {
                var planetsList = await _planetService.GetRegisters();
                return Results.Ok(planetsList);
            }).WithName("GetPlanets");

            endpoints.MapGet("/planets/{id}", async (IService<Planet> _planetService, int id) =>
            {
                var planet = await _planetService.GetRegisterById(id);
                if (planet != null) return Results.Ok(planet);
                return Results.NotFound();
            }).WithName("GetPlanetById");

            endpoints.MapPut("/planets/{id}", async (IService<Planet> _planetService, int id, Planet planet) =>
            {
                var updatedPlanet = await _planetService.UpdateRegister(id, planet);
                if (updatedPlanet != null) return Results.Ok(updatedPlanet);
                return Results.NotFound();
            }).WithName("UpdatePlanet");

            endpoints.MapDelete("/planets/{id}", async (IService<Planet> _planetService, int id) =>
            {
                var deleteResult = await _planetService.DeleteRegister(id);
                if (deleteResult) return Results.Ok();
                return Results.NotFound();
            }).WithName("DeletePlanet");
        }
    }
}