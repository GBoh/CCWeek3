using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieRepositoryPattern.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Director { get; set; }
        public IList<Actor> Actors { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}