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
        public IEnumerable<ReviewListItem> GetReviews()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Reviews
                        .Where(e => e.AuthorId == _userId)
                        .Select(
                            e =>
                                new ReviewListItem
                                {
                                    ReviewId = e.ReviewId,
                                    AuthorName = e.AuthorName,
                                    CreatedUtc = e.CreatedUtc
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
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }
        
    }
}
