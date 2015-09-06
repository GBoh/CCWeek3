using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace IdentityWoot.Models {
    public class Repository : IRepository {
        private ApplicationDbContext _db;

        public Repository(ApplicationDbContext db) {
            _db = db;
        }

        private IList<string> _cacheNames = new List<string>();

        ///<summary>
        ///Generic query method
        ///</summary>
        public IQueryable<T> Query<T>() where T : class {
            return _db.Set<T>().AsQueryable();
        }


        /// <summary>
        /// List method
        /// </summary>
        public IList<T> List<T>() where T : class {
            return Query<T>().ToList();
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