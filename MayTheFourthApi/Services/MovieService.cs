using MayTheFourthApi.Data;
using MayTheFourthApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MayTheFourthApi.Services
{
    public class MovieService : IService<Movie>
    {
        private AppDbContext _db;

        public MovieService(AppDbContext db)
        {
            _db = db;
        }

        public async Task AddRegister(Movie movie)
        {
            await _db.Movies.AddAsync(movie);
            await _db.SaveChangesAsync();
        }

        public async Task<bool> DeleteRegister(int id)
        {
            var movie = await _db.Movies.FirstOrDefaultAsync(x => x.Id == id);
            if (movie == null) return false;

            _db.Movies.Remove(movie);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<Movie?> GetRegisterById(int id)
        {
            return await _db.Movies.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Movie>> GetRegisters()
        {
            return _db.Movies;
        }

        public async Task<Movie> UpdateRegister(int id, Movie movie)
        {
            var movieToBeUpdated = await _db.Movies.FirstOrDefaultAsync(x => x.Id == id);
            if (movieToBeUpdated == null) return null;

            movieToBeUpdated.Title = movie.Title;
            movieToBeUpdated.Episode = movie.Episode;
            movieToBeUpdated.OpeningCrawl = movie.OpeningCrawl;
            movieToBeUpdated.Director = movie.Director;
            movieToBeUpdated.Producer = movie.Producer;
            movieToBeUpdated.ReleaseDate = movie.ReleaseDate;

            _db.Movies.Update(movieToBeUpdated);
            await _db.SaveChangesAsync();

            return movieToBeUpdated;
        }
    }
}
