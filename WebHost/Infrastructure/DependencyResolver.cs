using BAL.Interfaces;
using BAL.Service;
using Ninject.Modules;

namespace WebHost.Infrastructure
{
    public class WebHostModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IGameService>().To<GameService>();
            Bind<ICommentService>().To<CommentService>();
        }
    }
}