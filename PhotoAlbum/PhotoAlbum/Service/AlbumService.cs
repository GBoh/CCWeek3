using AutoMapper;
using PhotoAlbum.Domain;
using PhotoAlbum.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PhotoAlbum.Service {
    public class AlbumService {
        private IRepository _repo;

        public AlbumService(IRepository repo) {
            _repo = repo;
        }

        public IList<AlbumDTO> ListAlbums() {
            var dtoList = new List<AlbumDTO>();
            var albums = _repo.Query<Album>().ToList();

            foreach (Album a in albums) {
                dtoList.Add(Mapper.Map<AlbumDTO>(a));
            }
            return dtoList;
        }

        public void AddAlbum(AlbumDTO newAblum) {
            Album album = new Album {
                Title = newAblum.Title,
                Photos = newAblum.Photos
            };

            _repo.Add<Album>(album);
            _repo.SaveChanges();

            //return Mapper.Map<AlbumDTO>(album);
        }

        public IList<PhotoDTO> ListPhotos(AlbumDTO album) {
            return (from a in _repo.Query<Album>().Include(a => a.Photos)
             where a.Title == album.Title
             select a) as IList<PhotoDTO>;
        }
    }
}