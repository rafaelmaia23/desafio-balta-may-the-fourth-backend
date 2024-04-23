using MayTheFourthApi.Data;
using MayTheFourthApi.Models;
using MayTheFourthApi.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace MayTheFourthApi.Services
{
    public class CharacterService : ICharacterService
    {
        private AppDbContext _db;

        public CharacterService(AppDbContext db)
        {
            _db = db;
        }

        public async Task AddCharacter(Character character)
        {
            await _db.Characters.AddAsync(character);
            await _db.SaveChangesAsync();
        }

        public async Task<bool> DeleteCharacter(int id)
        {
            var character = await _db.Characters.FirstOrDefaultAsync(x => x.Id == id); ;
            if (character == null) return false;
            else
            {
                _db.Characters.Remove(character);
                await _db.SaveChangesAsync();
                return true;
            }
        }

        public async Task<Character?> GetCharacterById(int id)
        {
            return await _db.Characters.FirstOrDefaultAsync(x => x.Id==id);
        }

        public async Task<IEnumerable<Character>> GetCharacters()
        {
            return _db.Characters;
        }

        public async Task<Character> UpdateCharacter(int id, Character character)
        {
            var characterToBeUpdated = await _db.Characters.FirstOrDefaultAsync(x => x.Id == id);
            if (characterToBeUpdated == null) return null;
            else
            {
                characterToBeUpdated.Name = character.Name;
                characterToBeUpdated.Height = character.Height;
                characterToBeUpdated.Weigth = character.Weigth;
                characterToBeUpdated.HairColor = character.HairColor;
                characterToBeUpdated.SkinColor = character.SkinColor;
                characterToBeUpdated.EyeColor = character.EyeColor;
                characterToBeUpdated.BirthYear = character.BirthYear;
                characterToBeUpdated.Gender = character.Gender;

                _db.Characters.Update(characterToBeUpdated);
                await _db.SaveChangesAsync();
                return characterToBeUpdated;
            }
        }
    }
}
