using AutoMapper;
using PhotoAlbum.Domain;
using PhotoAlbum.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoAlbum.Service {
    public class PhotoService {

        private IRepository _repo;

        public PhotoService(IRepository repo) {
            _repo = repo;
        }


        public void AddPhoto(PhotoDTO newPhoto, string url) {
            Photo photo = new Photo {
                ImageURL = url,
                Title = newPhoto.Title,
                Rating = newPhoto.Rating,
                Description = newPhoto.Description,
            };

            _repo.Add<Photo>(photo);
            _repo.SaveChanges();
            //return Mapper.Map<PhotoDTO>(photo);
        }
    }
}