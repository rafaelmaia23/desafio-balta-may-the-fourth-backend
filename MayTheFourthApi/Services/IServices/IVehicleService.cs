using MayTheFourthApi.Models;

namespace MayTheFourthApi.Services.IServices
{
    public interface IVehicleService
    {
        Task AddVehicle(Vehicle vehicle);
        Task<bool> DeleteVehicle(int id);
        Task<Vehicle?> GetVehicleById(int id);
        Task<IEnumerable<Vehicle>> GetVehicles();
        Task<Vehicle> UpdateVehicle(int id, Vehicle vehicle);
    }
}
