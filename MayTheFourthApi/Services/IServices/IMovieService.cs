using MayTheFourthApi.Models;

namespace MayTheFourthApi.Services.IServices
{
    public interface IMovieService
    {
        Task AddMovie(Movie movie);
        Task<bool> DeleteMovie(int id);
        Task<Movie?> GetMovieById(int id);
        Task<IEnumerable<Movie>> GetMovies();
        Task<Movie> UpdateMovie(int id, Movie movie);
    }
} 
