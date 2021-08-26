using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
        private ReactionServices CreateGameServices()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var reactionServices = new GameServices(userId);
            return reactionServices;
        }

        public IHttpActionResult Post(GameCreate game)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateGameServices();

            if (!service.CreateGame(game))
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
            var games = service.GetGameByGameId(id);
            return Ok(games);
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateGameServices();

            if (!service.DeleteGame(id))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Put(GameEdit game)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateGameServices();

            if (!service.UpdateGame(game))
                return InternalServerError();

            return Ok();

        }
    }
}
