using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//Class that inherits from and sets attributes in IMoviesRepository.

namespace MovieCollection.Models
{
    public class EFMoviesRepository : IMoviesRepository
    {
        private MoviesDbContext _context;
        public EFMoviesRepository(MoviesDbContext context)
        {
            _context = context;
        }
        public IQueryable<Movie> Movies => _context.Movies;


        public void AddMovie(Movie movie)
        {
            Movie newmovie = new Movie
            {
                Category = movie.Category,
                Title = movie.Title,
                Year = movie.Year,
                Director = movie.Director,
                Rating = movie.Rating,
                Edited = movie.Edited,
                Lent = movie.Lent,
                Notes = movie.Notes
            };
            _context.Movies.Add(newmovie);
            _context.SaveChanges();
        }

        public void UpdateMovie(Movie movie)
        {
            _context.Movies.Find(movie.MovieID).Category = movie.Category;
            _context.Movies.Find(movie.MovieID).Title = movie.Title;
            _context.Movies.Find(movie.MovieID).Year = movie.Year;
            _context.Movies.Find(movie.MovieID).Director = movie.Director;
            _context.Movies.Find(movie.MovieID).Rating = movie.Rating;
            _context.Movies.Find(movie.MovieID).Edited = movie.Edited;
            _context.Movies.Find(movie.MovieID).Lent = movie.Lent;
            _context.Movies.Find(movie.MovieID).Notes = movie.Notes;
            _context.SaveChanges();
        }

        public void DeleteMovie(Movie movie)
        {
            _context.Movies.Remove(movie);
            _context.SaveChanges();
        }
    }
}