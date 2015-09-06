using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace PhotoAlbum.Infrastructure {
    public class Repository : IRepository {

        private DataContext _db;

        public Repository(DataContext db) {
            _db = db;
        }

        ///<summary>
        ///Generic query method
        ///</summary>
        public IQueryable<T> Query<T>() where T : class {
            return _db.Set<T>().AsQueryable();
        }

        /// <summary>
        /// Find row by id
        /// </summary>
        public T Find<T>(params object[] keyValues) where T : class {
            return _db.Set<T>().Find(keyValues);
        }

        /// <summary>
        /// Add new entity
        /// </summary>
        public void Add<T>(T entityToCreate) where T : class {
            _db.Set<T>().Add(entityToCreate);
        }

        public void Delete<T>(params object[] keyValues) where T : class {
            _db.Set<T>().Remove(Find<T>(keyValues));
        }

        /// <summary>
        /// Save changes and throw validation exceptions
        /// </summary>
        public void SaveChanges() {
            try {
                _db.SaveChanges();
            }
            catch (DbEntityValidationException dbVal) {
                var firstError = dbVal.EntityValidationErrors.First().ValidationErrors.First().ErrorMessage;
                throw new ValidationException(firstError);
            }
        }

        public void Dispose() {
            _db.Dispose();
        }
    }
}