using MayTheFourthApi.Models;
using MayTheFourthApi.Services;

namespace MayTheFourthApi.Routes
{
    public static class MoviesRoutes
    {
        public static void MapMovieRoutes(this IEndpointRouteBuilder endpoints)
        {
            endpoints.MapPost("/movies", async (Movie movie, IService<Movie> _movieService) =>
            {
                if (movie == null) TypedResults.BadRequest();
                await _movieService.AddRegister(movie);
                return Results.Created($"{movie.Id}", movie);
            }).WithName("AddMovie");

            endpoints.MapGet("/movies", async (IService<Movie> _movieService) =>
            {
                var moviesList = await _movieService.GetRegisters();
                return Results.Ok(moviesList);
            }).WithName("GetMovies");

            endpoints.MapGet("/movies/{id}", async (IService<Movie> _movieService, int id) =>
            {

                var movie = await _movieService.GetRegisterById(id);
                if (movie != null) return Results.Ok(movie);
                return Results.NotFound();
            }).WithName("GetMovieById");

            endpoints.MapPut("/movies/{id}", async (IService<Movie> _movieService, int id, Movie movie) =>
            {
                var updatedMovie = await _movieService.UpdateRegister(id, movie);
                if (updatedMovie != null) return Results.Ok(updatedMovie);
                return Results.NotFound();
            }).WithName("UpdateMovies");

            endpoints.MapDelete("/movies/{id}", async (IService<Movie> _movieService, int id) =>
            {
                var deleteResult = await _movieService.DeleteRegister(id);
                if (deleteResult) return Results.Ok();
                return Results.NotFound();
            }).WithName("DeleteMovies");
        }
    }
}
