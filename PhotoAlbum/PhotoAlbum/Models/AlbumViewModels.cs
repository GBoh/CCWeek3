using PhotoAlbum.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoAlbum.Models {
    public class AlbumDisplayViewModel {
        public IList<PhotoDTO> Photos { get; set; }
        public string Title { get; set; }
    }
}