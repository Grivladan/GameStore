using Model;
using System.Web.Mvc;
using BAL.Infrastructure;
using BAL.Interfaces;

namespace WebHost.Controllers
{
    public class GameController : Controller
    {
        private readonly IGameService _gameService;

        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpPost]
        [Route("games/new")]
        public ActionResult New(Game game)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _gameService.Create(game);
                    return Json("New game was successfully added");
                }
                catch (ValidationException ex)
                {
                    return new HttpStatusCodeResult(404, ex.Message);
                }
            }
            return new HttpStatusCodeResult(400);
        }

        [HttpPost]
        [Route("games/update")]
        public ActionResult Edit(Game game)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _gameService.Edit(game);
                    return Json("Game was edited");
                }
                catch (ValidationException ex)
                {
                    return new HttpStatusCodeResult(404, ex.Message);
                }
            }
            return new HttpStatusCodeResult(400);
        }

        [HttpGet]
        [Route("games")]
        public JsonResult GetAllGames()
        {
            var games = _gameService.GetAll();
            return Json(games, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [Route("game/{gameKey}")]
        public ActionResult GetGameDetails(string key)
        {
            try
            {
                var game = _gameService.GetGameByKey(key);
                return Json(game, JsonRequestBehavior.AllowGet);
            }
            catch (ValidationException ex)
            {
                return new HttpStatusCodeResult(404, ex.Message);
            }
        }


        [HttpPost]
        [Route("games/remove")]
        public ActionResult Delete(string key)
        {
            try
            {
                _gameService.Delete(key);
                return Json("Game was succesfully deleted");
            }
            catch (ValidationException ex)
            {
                return new HttpStatusCodeResult(404, ex.Message);
            }
        }
    }
}