using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProject.Data;
using FinalProject.Models;

namespace FinalProject.Services
{
    public class ReactionServices
    {
        private readonly Guid _userId;

        public ReactionServices(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateReaction(ReactionCreate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var review = ctx.Reviews.Find(model.ReviewId);
                var reaction = 
                    ctx
                    .Reactions
                    .SingleOrDefault(e => e.UserID == _userId && e.ReviewId == model.ReviewId);

                if (review is null)
                    return false;
                else if (reaction != null)
                {
                    return UpdateReaction(
                        new ReactionEdit()
                        {
                            ReactionId = reaction.ID,
                            Content = model.Content
                        }
                        );
                }
                else
                {
                    var entity = new Reaction()
                    {
                        UserID = _userId,
                        ReviewId = model.ReviewId,
                        Content = model.Content,
                        CreatedUtc = DateTimeOffset.UtcNow
                    };

                    ctx.Reactions.Add(entity);
                    return ctx.SaveChanges() == 1;
                }
            }
        }

        public IEnumerable<ReactionListItem> GetReactionsByReviewId(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Reactions
                        .Where(e => e.ReviewId == id)
                        .Select
                        (
                            e =>
                                new ReactionListItem
                                {
                                    ReactionId = e.ID,
                                    Content = e.Content,
                                    CreatedUtc = e.CreatedUtc
                                }
                        );

                return query.ToArray();
            }
        }

        public bool DeleteReaction(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Reactions
                        .Single(e => e.ID == id && e.UserID == _userId);

                ctx.Reactions.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public bool UpdateReaction(ReactionEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Reactions
                        .Single(e => e.ID == model.ReactionId && e.UserID == _userId);

                entity.Content = model.Content;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
