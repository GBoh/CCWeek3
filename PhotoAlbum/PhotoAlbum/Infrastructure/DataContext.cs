using PhotoAlbum.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PhotoAlbum.Infrastructure {
    public class DataContext : DbContext {
        public IDbSet<Album>Albums { get; set; }
        public IDbSet<Photo> Photos { get; set; }

    }
}