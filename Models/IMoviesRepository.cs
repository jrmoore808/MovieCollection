using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//Class for accessing the database _repository in the controller.

namespace MovieCollection.Models
{
    public interface IMoviesRepository
    {
        IQueryable<Movie> Movies { get; }
        void AddMovie(Movie movie);
        void UpdateMovie(Movie movie);
        void DeleteMovie(Movie movie);
    }
}
