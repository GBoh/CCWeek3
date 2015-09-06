using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace IdentityWoot.Models {
    public interface IRepository : IDisposable {
        void Add<T>(T entityToCreate) where T : class;
        void Delete<T>(params object[] keyValues) where T : class;
        T Find<T>(params object[] keyValues) where T : class;
        IList<T> List<T>() where T : class;
        IQueryable<T> Query<T>() where T : class;
        void SaveChanges();
    }

    /// <summary>
    /// This class promotes the Include() method from the entity framework so it
    /// can be used at a higher layer. You might not want to reference in the Entity Framework
    /// in your presentation layer.
    /// </summary>
    public static class GenericRepositoryExtensions {
        public static IQueryable<T> Include<T, TProperty>(this IQueryable<T> queryable, Expression<Func<T, TProperty>> relatedEntity) where T : class {
            return System.Data.Entity.QueryableExtensions.Include<T, TProperty>(queryable, relatedEntity);
        }
    }
}