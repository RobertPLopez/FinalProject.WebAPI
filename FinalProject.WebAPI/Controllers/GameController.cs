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
using FinalProject.Services;

namespace FinalProject.WebAPI.Controllers
{
    [Authorize]
    public class GameController : ApiController
    {
        private GameServices CreateGameServices()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var reactionServices = new GameServices(userId);
            return reactionServices;
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
    }
}
