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
    public class ReactionController : ApiController
    {
        private ReactionServices CreateReactionServices()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var reactionServices = new ReactionServices(userId);
            return reactionServices;
        }

        public IHttpActionResult Post(ReactionCreate reaction)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateReactionServices();

            if (!service.CreateReaction(reaction))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Get(int id)
        {
            var service = CreateReactionServices();
            var reactions = service.GetReactionsByReviewId(id);

            if (reactions is null)
                return BadRequest("No reactions");

            return Ok(reactions);
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateReactionServices();

            if (!service.DeleteReaction(id))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Put(ReactionEdit reaction)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateReactionServices();

            if (!service.UpdateReaction(reaction))
                return InternalServerError();

            return Ok();

        }
    }
}
