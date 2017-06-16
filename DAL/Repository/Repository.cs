using DAL.Interface;
using Model;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAL.Repository
{
    public class Repository<T> : IRepository<T> where T : class, IEntity
    {
        private readonly DbContext _context;
        private DbSet<T> _entities;

        public Repository(DbContext context)
        {
            _context = context;
        }

        public IEnumerable<T> GetAll()
        {
            return Query.ToList();
        }

        public T GetById(int id)
        {
            return Query.FirstOrDefault(x => x.Id == id);
        }

        public void Create(T item)
        {
            Entities.Add(item);
        }

        public void Update(T item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }

        public void Delete(T item)
        {
            Entities.Remove(item);
        }

        protected IDbSet<T> Entities
        {
            get { return _entities ?? (_entities = _context.Set<T>()); }
        }

        public IQueryable<T> Query
        {
            get { return Entities; }
        }
    }
}
