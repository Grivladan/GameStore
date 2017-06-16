using Model;

namespace DAL.Interface
{
    public interface IUnitOfWork
    {
        IRepository<Game> Games { get; }
        IRepository<Comment> Comments { get; }

        void Save();
    }
}
