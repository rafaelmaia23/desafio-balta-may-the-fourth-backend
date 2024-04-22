﻿using MayTheFourthApi.Data;
using MayTheFourthApi.Models;
using MayTheFourthApi.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace MayTheFourthApi.Services
{
    public class MovieService : IMovieService
    {
        private AppDbContext _db;

        public MovieService(AppDbContext db)
        {
            _db = db;
        }

        public async Task AddMovie(Movie movie)
        {
            await _db.Movies.AddAsync(movie);
            await _db.SaveChangesAsync();
        }

        public async Task<bool> DeleteMovie(int id)
        {
            var movie = await _db.Movies.FirstOrDefaultAsync(x => x.Id == id);
            if (movie == null) return false;
            else
            {
                _db.Movies.Remove(movie);
                await _db.SaveChangesAsync();
                return true;
            }
        }

        public async Task<Movie?> GetMovieById(int id)
        {
            return await _db.Movies.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Movie>> GetMovies()
        {
            return _db.Movies;
        }

        public async Task<Movie> UpdateMovie(int id, Movie movie)
        {
            var movieToBeUpdated = await _db.Movies.FirstOrDefaultAsync(x => x.Id == id);
            if (movieToBeUpdated == null) return null;
            else
            {
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
}