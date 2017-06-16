using System.Collections.Generic;
using Model;

namespace BAL.Interfaces
{
    public interface ICommentService
    {
        void AddCommentToComment(int commentId, Comment comment);
        void AddCommentToGame(string key, Comment comment);
        IEnumerable<Comment> GetCommentsByGameKey(string key);
    }
}
