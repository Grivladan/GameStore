using System.Collections.Generic;

namespace Model
{
    public class Game : IEntity
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Genre> Genres { get; set; }
        public virtual ICollection<PlatformType> Platforms { get; set; }

        public Game()
        {
            Comments = new List<Comment>();
            Genres = new List<Genre>();
            Platforms = new List<PlatformType>();
        }
    }
}
