using MayTheFourthApi.Models;
using MayTheFourthApi.Services;

namespace MayTheFourthApi.Routes
{
    public static class VehicleRoutes
    {
        public static void MapVehicleRoutes(this IEndpointRouteBuilder endpoints)
        {
            endpoints.MapPost("/vehicles", async (Vehicle vehicle, IService<Vehicle> _vehicleService) =>
            {
                if (vehicle == null) TypedResults.BadRequest();
                await _vehicleService.AddRegister(vehicle);
                return Results.Created($"{vehicle.Id}", vehicle);
            }).WithName("AddVehicle");

            endpoints.MapGet("/vehicles", async (IService<Vehicle> _vehicleService) =>
            {
                var vehiclesList = await _vehicleService.GetRegisters();
                return Results.Ok(vehiclesList);
            }).WithName("GetVehicles");

            endpoints.MapGet("/vehicles/{id}", async (IService<Vehicle> _vehicleService, int id) =>
            {
                var vehicle = await _vehicleService.GetRegisterById(id);
                if (vehicle != null) return Results.Ok(vehicle);
                return Results.NotFound();
            }).WithName("GetVehicleById");

            endpoints.MapPut("/vehicles/{id}", async (IService<Vehicle> _vehicleService, int id, Vehicle vehicle) =>
            {
                var updatedVehicle = await _vehicleService.UpdateRegister(id, vehicle);
                if (updatedVehicle != null) return Results.Ok(updatedVehicle);
                return Results.NotFound();
            }).WithName("UpdateVehicle");

            endpoints.MapDelete("/vehicles/{id}", async (IService<Vehicle> _vehicleService, int id) =>
            {
                var deleteResult = await _vehicleService.DeleteRegister(id);
                if (deleteResult) return Results.Ok();
                return Results.NotFound();
            }).WithName("DeleteVehicle");
        }
    }
}