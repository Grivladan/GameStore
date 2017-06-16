using Model;
using System.Collections.Generic;

namespace BAL.Interfaces
{
    public interface IGameService
    {
        void Create(Game game);
        void Edit(Game game);
        void Delete(string key);
        IEnumerable<Game> GetAll();
        IEnumerable<Game> GetGamesByGenre(Genre genre);
        IEnumerable<Game> GetGamesByPlatformType(PlatformType platformType);
        Game GetGameByKey(string key);
    }
}
