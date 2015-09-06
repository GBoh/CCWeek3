﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoAlbum.Domain {
    public class Album {
        public int Id { get; set; }
        public string Title { get; set; }
        public IList<Photo> Photos { get; set; }
    }
}