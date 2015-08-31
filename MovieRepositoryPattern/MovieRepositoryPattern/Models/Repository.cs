using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MovieRepositoryPattern.Models
{
    public class Repository : IRepository
    {
        private DataContext _db;

        public Repository(DataContext db)
        {
            _db = db;
        }

        public IList<Movie> ListMovies()
        {
            return (from m in _db.Movies select m).ToList();
        }

        public void CreateMovie (Movie movie)
        {
            _db.Movies.Add(movie);
            _db.SaveChanges();
        }

        public Movie FindMovie (int id)
        {
            return (from m in _db.Movies
                    where m.Id == id
                    select m).FirstOrDefault();

        }

        public void UpdateMovie (Movie movie)
        {
            var dbMovie = FindMovie(movie.Id);
            dbMovie.Name = movie.Name;
            dbMovie.Director = movie.Director;
            dbMovie.ReleaseDate = movie.ReleaseDate;
            _db.SaveChanges();

        }
        public void DeleteMovie (int id)
        {
            var dbMovie = FindMovie(id);
            _db.Movies.Remove(dbMovie);
            _db.SaveChanges();
        }
    }
}