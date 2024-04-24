using MayTheFourthApi.Data;
using MayTheFourthApi.Models;
using MayTheFourthApi.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace MayTheFourthApi.Services
{
    public class StarShipService : IService<StarShip>
    {
        private AppDbContext _db;

        public StarShipService(AppDbContext db)
        {
            _db = db;
        }
        public async Task AddRegister(StarShip starShip)
        {
            await _db.StarShips.AddAsync(starShip);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<StarShip>> GetRegisters()
        {
            return _db.StarShips;
        }

        public async Task<StarShip?> GetRegisterById(int id)
        {
            return await _db.StarShips.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<StarShip> UpdateRegister(int id, StarShip starShip)
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

        public async Task<bool> DeleteRegister(int id)
        {
            var starShip = await _db.StarShips.FirstOrDefaultAsync(x => x.Id == id);
            if (starShip == null) return false;

            _db.StarShips.Remove(starShip);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
