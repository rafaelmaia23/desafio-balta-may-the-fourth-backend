using MayTheFourthApi.Models;

namespace MayTheFourthApi.Services.IServices
{
    public interface IPlanetService
    {
        Task AddPlanet(Planet planet);
        Task<bool> DeletePlanet(int id);
        Task<Planet?> GetPlanetById(int id);
        Task<IEnumerable<Planet>> GetPlanets();
        Task<Planet> UpdatePlanet(int id,  Planet planet);
    }
}
