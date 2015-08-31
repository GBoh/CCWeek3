using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieRepositoryPattern.Models
{
    public class Actor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DOB { get; set; }
        public IList<Movie> Movies { get; set; }
    }
}