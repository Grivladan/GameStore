using Model;
using System.Data.Entity;

namespace DAL.EF
{
    class GameStoreInitializer : CreateDatabaseIfNotExists<GameStoreContext>
    {
        protected override void Seed(GameStoreContext context)
        {
            Genre strategy = new Genre() { Name = "Strategy"};
            Genre races = new Genre() { Name = "Races" };
            Genre action = new Genre() { Name = "Action" };

            context.Genres.Add(strategy);
            context.Genres.Add(races);
            context.Genres.Add(action);
            context.Genres.Add(new Genre(){ Name = "RPG"});
            context.Genres.Add(new Genre() { Name = "RPG" });
            context.Genres.Add(new Genre() { Name = "Sports"});
            context.Genres.Add(new Genre() { Name = "Adventure" });
            context.Genres.Add(new Genre() { Name = "Puzzle&Skills" });
            context.Genres.Add(new Genre() { Name = "Mics" });
            context.Genres.Add(new Genre() { Name = "RTS", NestedGenre = strategy });
            context.Genres.Add(new Genre() { Name = "TBS", NestedGenre = strategy });
            context.Genres.Add(new Genre() { Name = "Rally", NestedGenre = races });
            context.Genres.Add(new Genre() { Name = "Arcade", NestedGenre = races });
            context.Genres.Add(new Genre() { Name = "Formula", NestedGenre = races });
            context.Genres.Add(new Genre() { Name = "Off-road", NestedGenre = races });
            context.Genres.Add(new Genre() { Name = "FPS", NestedGenre = action });
            context.Genres.Add(new Genre() { Name = "TPS", NestedGenre = action });
            context.Genres.Add(new Genre() { Name = "Misc", NestedGenre = action });

            context.Types.Add(new PlatformType() { Type = "Mobile" });
            context.Types.Add(new PlatformType() { Type = "Browser" });
            context.Types.Add(new PlatformType() { Type = "Desktop" });
            context.Types.Add(new PlatformType() { Type = "Console" });

            context.SaveChanges();
        }
    }
}
