using MayTheFourthApi.Models;
using MayTheFourthApi.Services;

namespace MayTheFourthApi.Routes
{
    public static class CharacterRoutes
    {
        public static void MapCharacterRoutes(this IEndpointRouteBuilder endpoints)
        {
            endpoints.MapPost("/characters", async (Character character, IService<Character> _characterService) =>
            {
                if (character == null) TypedResults.BadRequest();
                await _characterService.AddRegister(character);
                return Results.Created($"{character.Id}", character);
            }).WithName("AddCharacter");

            endpoints.MapGet("/characters", async (IService<Character> _characterService) =>
            {
                var charactersList = await _characterService.GetRegisters();
                return Results.Ok(charactersList);
            }).WithName("GetCharacters");

            endpoints.MapGet("/characters/{id}", async (IService<Character> _characterService, int id) =>
            {
                var character = await _characterService.GetRegisterById(id);
                if (character != null) return Results.Ok(character);
                return Results.NotFound();
            }).WithName("GetCharacterById");

            endpoints.MapPut("/characters/{id}", async (IService<Character> _characterService, int id, Character character) =>
            {
                var updatedCharacter = await _characterService.UpdateRegister(id, character);
                if (updatedCharacter != null) return Results.Ok(updatedCharacter);
                return Results.NotFound();
            }).WithName("UpdateCharacters");

            endpoints.MapDelete("/characters/{id}", async (IService<Character> _characterService, int id) =>
            {
                var deleteResult = await _characterService.DeleteRegister(id);
                if (deleteResult) return Results.Ok();
                return Results.NotFound();
            }).WithName("DeleteCharacters");
        }
    }
}