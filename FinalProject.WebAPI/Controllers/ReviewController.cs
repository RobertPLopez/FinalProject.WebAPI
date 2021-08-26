using FinalProject.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FinalProject.WebAPI.Controllers
{
    public class ReviewController : ApiController
    {
        private ReviewService CreateReviewService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var reviewService = new ReviewService(userId);
        }

        public IHttpActionResult Get()
        {

        }

    }
}
