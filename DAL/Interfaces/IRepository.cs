using Model;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Interface
{
    public interface IRepository<T> where T : class, IEntity
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Create(T item);
        void Update(T item);
        void Delete(T item);

        IQueryable<T> Query { get; }
    }
}
