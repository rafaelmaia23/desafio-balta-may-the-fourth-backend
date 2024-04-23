using MayTheFourthApi.Models;

namespace MayTheFourthApi.Services.IServices
{
    public interface IStarShipService
    {
        Task AddStarShip(StarShip starShip);
        Task<bool> DeleteStarShip(int id);
        Task<StarShip?> GetStarShipById(int id);
        Task<IEnumerable<StarShip>> GetStarShips();
        Task<StarShip> UpdateStarShip(int id, StarShip starShip);
    }
}
