using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MovieRepositoryPattern.Models
{
    public class DataContext : DbContext
    {
        public IDbSet<Movie> Movies { get; set; }
        public IDbSet<Actor> Actors { get; set; }
    }
}