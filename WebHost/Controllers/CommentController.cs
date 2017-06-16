using System.Web.Mvc;
using BAL.Interfaces;
using Model;
using BAL.Infrastructure;

namespace WebHost.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet]
        [Route("game/{gameKey}/comments")]
        public ActionResult GetCommentsByKey(string key)
        {
            var comments = _commentService.GetCommentsByGameKey(key);
            return Json(comments, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [Route("game/{gameKey}/comments")]
        public ActionResult CommentGame(string key, Comment comment)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _commentService.AddCommentToGame(key, comment);
                    return Json("Comment was added");
                }
                catch (ValidationException ex)
                {
                    return new HttpStatusCodeResult(404, ex.Message);
                }
            }
            return new HttpStatusCodeResult(400);
        }

        [HttpPost]
        [Route("game/{parentCommentId:int}/newcomment")]
        public ActionResult CommentAnotherComment(int parentCommentId, Comment comment)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _commentService.AddCommentToComment(parentCommentId, comment);
                    return Json("Comment was added");
                }
                catch (ValidationException ex)
                {
                    return new HttpStatusCodeResult(404, ex.Message);
                }
            }
            return new HttpStatusCodeResult(400);
        }
    }
}