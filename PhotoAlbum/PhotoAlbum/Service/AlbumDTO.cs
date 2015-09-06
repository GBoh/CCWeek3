using PhotoAlbum.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoAlbum.Service {
    public class AlbumDTO {
        public string Title { get; set; }
        public IList<Photo> Photos { get; set; }
    }
}