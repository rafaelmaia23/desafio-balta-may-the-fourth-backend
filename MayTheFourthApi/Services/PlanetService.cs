using MayTheFourthApi.Data;
using MayTheFourthApi.Models;
using MayTheFourthApi.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace MayTheFourthApi.Services
{
    public class PlanetService : IService<Planet>
    {
        private AppDbContext _db;

        public PlanetService(AppDbContext db)
        {
            _db = db;
        }

        public async Task AddRegister(Planet planet)
        {
            await _db.Planets.AddAsync(planet);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Planet>> GetRegisters()
        {
            return _db.Planets;
        }

        public async Task<Planet?> GetRegisterById(int id)
        {
            return await _db.Planets.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Planet> UpdateRegister(int id, Planet planet)
        {
            var planetToBeUpdated = await _db.Planets.FirstOrDefaultAsync(x => x.Id == id);
            if (planetToBeUpdated == null) return null;

            planetToBeUpdated.Name = planet.Name;
            planetToBeUpdated.RotationPeriod = planet.RotationPeriod;
            planetToBeUpdated.OrbitalPeriod = planet.OrbitalPeriod;
            planetToBeUpdated.Diameter = planet.Diameter;
            planetToBeUpdated.Climate = planet.Climate;
            planetToBeUpdated.Gravity = planet.Gravity;
            planetToBeUpdated.Terrain = planet.Terrain;
            planetToBeUpdated.SurfaceWater = planet.SurfaceWater;
            planetToBeUpdated.Population = planet.Population;

            _db.Planets.Update(planetToBeUpdated);
            await _db.SaveChangesAsync();
            return planetToBeUpdated;
        }

        public async Task<bool> DeleteRegister(int id)
        {
            var planet = await _db.Planets.FirstOrDefaultAsync(x => x.Id == id);
            if (planet == null) return false;

            _db.Planets.Remove(planet);
            await _db.SaveChangesAsync();

            return true;
        }
    }
}
