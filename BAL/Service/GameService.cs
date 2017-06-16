using System;
using System.Collections.Generic;
using System.Linq;
using BAL.Infrastructure;
using BAL.Interfaces;
using DAL.Interface;
using Model;

namespace BAL.Service
{
    public class GameService : IGameService
    {
        private readonly IUnitOfWork _unitOfWork;
        public GameService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Create(Game game)
        {
            _unitOfWork.Games.Create(game);
            _unitOfWork.Save();
        }

        public void Delete(string key)
        {
            var game = _unitOfWork.Games.Query.FirstOrDefault(g => g.Key == key);
            if (game == null)
                throw new ValidationException("Game doesn't exist", "");
            _unitOfWork.Games.Delete(game);
            _unitOfWork.Save();
        }

        public void Edit(Game game)
        {
            _unitOfWork.Games.Update(game);
            _unitOfWork.Save();
        }

        public IEnumerable<Game> GetAll()
        {
            var games = _unitOfWork.Games.GetAll();
            return games;
        }

        public Game GetGameByKey(string key)
        {
            var game = _unitOfWork.Games.Query.FirstOrDefault(g => g.Key == key);
            if(game == null)
                throw new ValidationException("Game doesn't exist", "");
            return game;
        }

        public IEnumerable<Game> GetGamesByGenre(Genre genre)
        {
            var games = _unitOfWork.Games.Query.Where(g => g.Genres.Contains(genre));
            return games;
        }

        public IEnumerable<Game> GetGamesByPlatformType(PlatformType platformType)
        {
            var games = _unitOfWork.Games.Query.Where(g => g.Platforms.Contains(platformType));
            return games;
        }
    }
}
