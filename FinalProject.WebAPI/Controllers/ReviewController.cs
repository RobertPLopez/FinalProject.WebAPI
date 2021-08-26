using FinalProject.Models;
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
    /*

Delete Review

*/
    public class ReviewController : ApiController
    {
        private ReviewService CreateReviewService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var reviewService = new ReviewService(userId);
            return reviewService;
        }

        public IHttpActionResult Get()
        {
            ReviewService reviewService = CreateReviewService();
            var review = reviewService.GetReviews();
            return Ok(review);
        }
        public IHttpActionResult Get(int id)
        {
            ReviewService reviewService = CreateReviewService();
            var review = reviewService.GetReviewById(id);
            return Ok(review);
        }

        public IHttpActionResult Post(ReviewCreate review)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateReviewService();

            if (!service.CreateReview(review))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Put(ReviewUpdate review)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateReviewService();

            if (!service.UpdateReview(review))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Delete(int id)
        {
            var service = CreateReviewService();

            if (!service.DeleteReview(id))
                return InternalServerError();

            return Ok();
        }
    }
}
