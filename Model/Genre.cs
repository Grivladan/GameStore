using System;
using System.Collections.Generic;

namespace Model
{
    public class Genre : IEntity
    {
         public int Id { get; set; }
         public string Name { get; set; }
         public int? NestedGenreId { get; set; }
         public Genre NestedGenre { get; set; }
         public virtual ICollection<Game> Games { get; set; }

        public Genre()
        {
            Games = new List<Game>();
        }
    }
}
