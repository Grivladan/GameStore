using DAL.Interface;
using Model;
using System.Data.Entity;

namespace DAL.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private DbContext _context;
        private bool _isDisposed;
        private readonly IRepositoryFactory _repositoryFactory;

        public UnitOfWork(DbContext context, IRepositoryFactory repositoryFactory)
        {
            _context = context;
            _repositoryFactory = repositoryFactory;
        }

        private IRepository<Game> _gameRepository;
        private IRepository<Comment> _commentRepository;
        private IRepository<Genre> _genreRepository;
        private IRepository<PlatformType> _platformTypeRepository;

        public IRepository<Game> Games
        {
            get
            {
                return _gameRepository ?? (_gameRepository = _repositoryFactory.CreateRepository<Game>(_context));
            }
        }

        public IRepository<Comment> Comments
        {
            get
            {
                return _commentRepository ?? (_commentRepository = _repositoryFactory.CreateRepository<Comment>(_context));
            }
        }

        public IRepository<Genre> Genres
        {
            get
            {
                return _genreRepository ?? (_genreRepository = _repositoryFactory.CreateRepository<Genre>(_context));
            }
        }

        public IRepository<PlatformType> PlatformTypes
        {
            get
            {
                return _platformTypeRepository ?? (_platformTypeRepository = _repositoryFactory.CreateRepository<PlatformType>(_context));
            }
        }

        public virtual void Dispose(bool disposing)
        {
            if (!_isDisposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }

            _isDisposed = true;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
