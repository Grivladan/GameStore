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

        public DbSet<Game> Products { get; set; }
        public DbSet<Comment> Orders { get; set; }

        public static GameStoreContext Create()
        {
            return new GameStoreContext();
        }
    }
}
