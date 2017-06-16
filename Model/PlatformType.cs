using System.Collections.Generic;

namespace Model
{
    public class PlatformType : IEntity
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public virtual ICollection<Game> Games { get; set; }

        public PlatformType()
        {
            Games = new List<Game>();
        }
    }
}
