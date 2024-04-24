using MayTheFourthApi.Data;
using MayTheFourthApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MayTheFourthApi.Services
{
    public class CharacterService : IService<Character>
    {
        private AppDbContext _db;

        public CharacterService(AppDbContext db)
        {
            _db = db;
        }

        public async Task AddRegister(Character character)
        {
            await _db.Characters.AddAsync(character);
            await _db.SaveChangesAsync();
        }

        public async Task<bool> DeleteRegister(int id)
        {
            var character = await _db.Characters.FirstOrDefaultAsync(x => x.Id == id); ;
            if (character == null) return false;

            _db.Characters.Remove(character);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<Character?> GetRegisterById(int id)
        {
            return await _db.Characters.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Character>> GetRegisters()
        {
            return _db.Characters;
        }

        public async Task<Character> UpdateRegister(int id, Character character)
        {
            var characterToBeUpdated = await _db.Characters.FirstOrDefaultAsync(x => x.Id == id);
            if (characterToBeUpdated == null) return null;

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
