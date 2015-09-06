using AutoMapper;
using PhotoAlbum.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoAlbum.Service {
    public class AutoMapperConfig {
        public static void RegisterMaps() {
            Mapper.CreateMap<PhotoDTO, Photo>();
            Mapper.CreateMap<AlbumDTO, Album>();

            Mapper.CreateMap<Photo, PhotoDTO>();
            Mapper.CreateMap<Album, AlbumDTO>();
        }
    }
}