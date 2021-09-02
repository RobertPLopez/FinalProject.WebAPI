using System;
using System.Web.Http;
using FinalProject.Data;
using FinalProject.Models;
using FinalProject.Services;
using Microsoft.AspNet.Identity;


namespace FinalProject.WebAPI.Controllers
{
    [Authorize]
    public class GameController : ApiController
    {
        private GameService CreateGameServices()
        {
            var gameId = int.Parse(User.Identity.GetUserId());
            var reactionServices = new GameService(gameId);
            return reactionServices;
        }

        public IHttpActionResult Post(GameCreate Game)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var Services = CreateGameServices();
            if (!Services.CreateGame(Game))
                return InternalServerError();
            return Ok();
        }

        public IHttpActionResult Get(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                if (ctx.Games.Find(id) is null)
                    return BadRequest("Invalid Request");
            }

            var service = CreateGameServices();
            var games = service.GetGamesByGameId(id);
            return Ok(games);
        }

        public IHttpActionResult Put(GameEdit Game)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateGameServices();
            if (!service.UpdateGame(Game))
                return InternalServerError();
            return Ok();

        }

        public IHttpActionResult Delete (int id)
        {
            var service = CreateGameServices();
            if (!service.DeleteGame(id))
                return InternalServerError();
            return Ok();
        }
    }
}
