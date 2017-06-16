using Model;
using System.Data.Entity;

namespace DAL.Interface
{
    public interface IRepositoryFactory
    {
        IRepository<T> CreateRepository<T>(DbContext context) where T : class, IEntity;
    }
}
