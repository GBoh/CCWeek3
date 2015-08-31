using System.Collections.Generic;

namespace MovieRepositoryPattern.Models
{
    public interface IRepository
    {
        void CreateMovie(Movie movie);
        void DeleteMovie(int id);
        Movie FindMovie(int id);
        IList<Movie> ListMovies();
        void UpdateMovie(Movie movie);
    }
}