using System;

namespace Model
{
    public class Comment : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Body { get; set; }
        public int CommentedGameId { get; set; }
        public virtual Game CommentedGame { get; set; }
        public int? CommentId { get; set; }
        public virtual Comment ParentComment { get; set; }
    }
}
