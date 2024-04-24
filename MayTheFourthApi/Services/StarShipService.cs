using MayTheFourthApi.Data;
using MayTheFourthApi.Models;
using MayTheFourthApi.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace MayTheFourthApi.Services
{
    public class StarShipService : IStarShipService
    {
        private AppDbContext _db;

        public StarShipService(AppDbContext db)
        {
            _db = db;
        }
        public async Task AddStarShip(StarShip starShip)
        {
            await _db.StarShips.AddAsync(starShip);
            await _db.SaveChangesAsync();
        }

        public async Task<bool> DeleteStarShip(int id)
        {
            var starShip = await _db.StarShips.FirstOrDefaultAsync(x => x.Id == id);
            if (starShip == null) return false;

            _db.StarShips.Remove(starShip);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<StarShip?> GetStarShipById(int id)
        {
            return await _db.StarShips.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<StarShip>> GetStarShips()
        {
            return _db.StarShips;
        }

        public async Task<StarShip> UpdateStarShip(int id, StarShip starShip)
        {
            var starShipToBeUpdated = await _db.StarShips.FirstOrDefaultAsync(x => x.Id == id);
            if (starShipToBeUpdated == null) return null;

            starShipToBeUpdated.Name = starShip.Name;
            starShipToBeUpdated.Manufacturer = starShip.Manufacturer;
            starShipToBeUpdated.CostInCredits = starShip.CostInCredits;
            starShipToBeUpdated.Length = starShip.Length;
            starShipToBeUpdated.MaxSpeed = starShip.MaxSpeed;
            starShipToBeUpdated.Crew = starShip.Crew;
            starShipToBeUpdated.Passengers = starShip.Passengers;
            starShipToBeUpdated.CargoCapacity = starShip.CargoCapacity;
            starShipToBeUpdated.HyperDriveRating = starShip.HyperDriveRating;
            starShipToBeUpdated.Mglt = starShip.Mglt;
            starShipToBeUpdated.Consumables = starShip.Consumables;
            starShipToBeUpdated.Class = starShip.Class;

            _db.StarShips.Update(starShipToBeUpdated);
            await _db.SaveChangesAsync();

            return starShipToBeUpdated;
        }
    }
}
