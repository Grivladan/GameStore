using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using BAL.Infrastructure;
using BAL.Interfaces;
using DAL.Interface;
using Model;

namespace BAL.Service
{
    public class CommentService : ICommentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CommentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void AddCommentToGame(string key, Comment comment)
        {
            var game = _unitOfWork.Games.Query.FirstOrDefault(g => g.Key == key);
            if(game == null)
                throw new ValidationException("Game doesn't exist", "");
            comment.CommentedGame = game;
            _unitOfWork.Comments.Create(comment);
            _unitOfWork.Save();
        }

        public void AddCommentToComment(int commentId, Comment comment)
        {
            var parentComment = _unitOfWork.Comments.GetById(commentId);
            if(parentComment == null)
                throw new ValidationException("Comment doesn't exist", "");
            comment.ParentComment = parentComment;
            comment.CommentedGame = parentComment.CommentedGame;
            comment.CommentedGameId = parentComment.CommentedGameId;
            _unitOfWork.Comments.Update(comment);
            _unitOfWork.Save();
        }

        public IEnumerable<Comment> GetCommentsByGameKey(string key)
        {
            var comments = _unitOfWork.Comments.Query.Where( x => x.CommentedGame.Key == key);
            return comments;
        }
    }
}
