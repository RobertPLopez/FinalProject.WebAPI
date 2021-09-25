using FinalProject.Data;
using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Services
{
    public class ReviewService
    {
        private readonly Guid _userId;

        public ReviewService(Guid userId)
        {
            _userId = userId;
        }
        public IEnumerable<ReviewDetail> GetReviews()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Reviews
                        .Where(e => e.AuthorId == _userId)
                        .Select(
                            e =>
                                new ReviewDetail
                                {
                                    ReviewId = e.ReviewId,
                                    AuthorName = e.AuthorName,
                                    Content = e.Content,
                                    Rating = e.Rating,
                                    CreatedUtc = e.CreatedUtc,
                                    ModifiedUtc = e.ModifiedUtc
                                }
                            );
                return query.ToArray();
            }
        }
        public ReviewDetail GetReviewById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Reviews.Single(e => e.ReviewId == id && e.AuthorId == _userId);
                return
                    new ReviewDetail
                    {
                        ReviewId = entity.ReviewId,
                        AuthorName = entity.AuthorName,
                        Content = entity.Content,
                        Rating = entity.Rating,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }
        
        public bool CreateReview(ReviewCreate model)
        {
            var entity = new Review()
            {
                AuthorId = _userId,
                AuthorName = model.AuthorName,
                Content = model.Content,
                Rating = model.Rating,
                CreatedUtc = DateTimeOffset.Now,
                GameID = model.GameID
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Reviews.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public bool UpdateReview(ReviewUpdate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Reviews
                        .Single(e => e.ReviewId == model.ReviewId && e.AuthorId == _userId);
                entity.AuthorName = model.AuthorName;
                entity.Content = model.Content;
                entity.Rating = model.Rating;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteReview(int reviewId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Reviews
                        .Single(e => e.ReviewId == reviewId && e.AuthorId == _userId);

                ctx.Reviews.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
