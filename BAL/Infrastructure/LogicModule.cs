using DAL.Interface;
using DAL.Repository;
using Ninject.Modules;

namespace BAL.Infrastructure
{
    public class LogicModule : NinjectModule
    {
        public override void Load()
        {

            Bind<IUnitOfWork>().To<UnitOfWork>();
        }
    }
}
