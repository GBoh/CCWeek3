using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoAlbum.Service {
    public class PhotoDTO {
        public string Title { get; set; }
        public string ImageURL { get; set; }
        public string Description { get; set; }
        public int Rating { get; set; }
    }
}