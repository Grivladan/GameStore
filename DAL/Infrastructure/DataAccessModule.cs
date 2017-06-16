using DAL.Interface;
using DAL.Repository;
using Ninject.Extensions.Factory;
using Ninject.Modules;
using System.Data.Entity;

namespace DAL.Infrastructure
{
    public class DataAccessModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IRepositoryFactory>().ToFactory();
            Bind<DbContext>().ToSelf();
            Bind(typeof(IRepository<>)).To(typeof(Repository<>));
        }
    }
}
