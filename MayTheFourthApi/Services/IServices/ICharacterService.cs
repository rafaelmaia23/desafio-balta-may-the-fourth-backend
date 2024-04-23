using MayTheFourthApi.Models;

namespace MayTheFourthApi.Services.IServices
{
    public interface ICharacterService
    {
        Task AddCharacter(Character character);
        Task<bool> DeleteCharacter(int id);
        Task<Character> GetCharacterById(int id);
        Task<IEnumerable<Character>> GetCharacters();
        Task<Character> UpdateCharacter(int id, Character character);
    }
}
