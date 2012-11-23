using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Objects;
using System.Linq;
using System.Linq.Expressions;
using MvcApplication1.Core;
using MvcApplication1.Core.Models;

namespace MvcApplication1.Data.Repositories
{
    public class BaseRepository
    {
        readonly PersonContext _context = new PersonContext();
        public PersonContext Context { get { return _context; } }

        public BaseRepository()
        {
            _context = new PersonContext();
        }

        public List<T> GetAll<T>(IEnumerable<Expression<Func<T, object>>> includeList = null) where T : BaseEntity
        {
            var dbSet = _context.Set<T>();

            if (includeList != null)
                dbSet = includeList.Aggregate(dbSet, (current, path) => ((IQueryable)current.Include(path)) as DbSet<T>);

            return (from e in dbSet select e).ToList();
        }

        public T Get<T>(int id, IEnumerable<Expression<Func<T, object>>> includeList = null) where T : BaseEntity
        {
            var dbSet = _context.Set<T>();

            if (includeList != null)
                dbSet = includeList.Aggregate(dbSet, (current, path) => ((IQueryable) current.Include(path)) as DbSet<T>);

            return (from e in dbSet where e.Id == id select e).FirstOrDefault();
        }

        public int Save<T>(T entity) where T : BaseEntity
        {
            var dbSet = _context.Set<T>();
            var dbEntity = Get<T>(entity.Id);

            if (dbEntity == null) { dbSet.Add(entity); }

            return _context.SaveChanges();
        }

        public int Delete<T>(T entity) where T : BaseEntity
        {
            var dbSet = _context.Set<T>();
            var dbEntity = Get<T>(entity.Id);

            if (dbEntity != null) { dbSet.Remove(dbEntity); }

            return _context.SaveChanges();
        }

        public bool IsDirty<T>(T entity) where T : BaseEntity
        {
            ObjectStateEntry objectStateEntry;
            if (_context.ObjectContext.ObjectStateManager.TryGetObjectStateEntry(entity, out objectStateEntry))
            {
                if (objectStateEntry.State == EntityState.Added || objectStateEntry.State == EntityState.Deleted || objectStateEntry.State == EntityState.Modified)
                    return true;
            }

            return false;
        }
    }
}