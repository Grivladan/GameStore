using Model;
using System.Data.Entity;

namespace DAL.EF
{
    public class GameStoreContext : DbContext
    {
        public GameStoreContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<Game> Games { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<PlatformType> Types { get; set; }

        public static GameStoreContext Create()
        {
            return new GameStoreContext();
        }
    }
}
