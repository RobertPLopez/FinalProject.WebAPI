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
            var userId = Guid.Parse(User.Identity.GetUserId());
            var gameServices = new GameService(userId);
            return gameServices;
        }

        public IHttpActionResult Post(GameCreate model)
        {
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var Services = CreateGameServices();

                if (!Services.CreateGame(model))
                {
                    return InternalServerError();
                }

                return Ok();
            }
        }


        public IHttpActionResult Get(Guid gameID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                if (ctx.Games.Find(gameID) is null)
                {
                    return BadRequest("Invalid Request");
                }
            }

            var service = CreateGameServices();
            var model = service.GetGameById(gameID);
            return Ok(model);
        }

        public IHttpActionResult Get()
        {
            using (var ctx = new ApplicationDbContext())
            {
                if (ctx.Games.Find() is null)
                {
                    return BadRequest("Invalid Request");
                }
            }

            var service = CreateGameServices();
            var model = service.GetAllGames();
            return Ok(model);
        }

        public IHttpActionResult Put(GameEdit model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateGameServices();
            if (!service.UpdateGame(model))
                return InternalServerError();
            return Ok();

        }

        public IHttpActionResult Delete(Guid gameID)
        {
            var service = CreateGameServices();
            if (!service.DeleteGame(gameID))
                return InternalServerError();
            return Ok();
        }
    }
}
