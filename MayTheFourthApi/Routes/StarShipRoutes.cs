using MayTheFourthApi.Models;
using MayTheFourthApi.Services;

namespace MayTheFourthApi.Routes
{
    public static class StarSchipRoutes
    {
        public static void MapStarSchipRoutes(this IEndpointRouteBuilder endpoints)
        {
            endpoints.MapPost("/starships", async (StarShip starShip, IService<StarShip> _starShipService) =>
            {
                if (starShip == null) TypedResults.BadRequest();
                await _starShipService.AddRegister(starShip);
                return Results.Created($"{starShip.Id}", starShip);
            }).WithName("AddStarShip");

            endpoints.MapGet("/starships", async (IService<StarShip> _starShipService) =>
            {
                var starShipsList = await _starShipService.GetRegisters();
                return Results.Ok(starShipsList);
            }).WithName("GetStarShips");

            endpoints.MapGet("/starships/{id}", async (IService<StarShip> _starShipService, int id) =>
            {
                var starShip = await _starShipService.GetRegisterById(id);
                if (starShip != null) return Results.Ok(starShip);
                return Results.NotFound();
            }).WithName("GetStarShipById");

            endpoints.MapPut("/starships/{id}", async (IService<StarShip> _starShipService, int id, StarShip starShip) =>
            {
                var updatedStarShip = await _starShipService.UpdateRegister(id, starShip);
                if (updatedStarShip != null) return Results.Ok(updatedStarShip);
                return Results.NotFound();
            }).WithName("UpdateStarShip");

            endpoints.MapDelete("/starships/{id}", async (IService<StarShip> _starShipService, int id) =>
            {
                var deleteResult = await _starShipService.DeleteRegister(id);
                if (deleteResult) return Results.Ok();
                return Results.NotFound();
            }).WithName("DeleteStarShip");
        }
    }
}