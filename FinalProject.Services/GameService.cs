using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Services
{
    class GameService
    {
        private readonly Guid _userId;

        public GameService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateGame(GameCreate model)
        {
            var entity =
                new Game()
                {
                    UserId = _userId,
                    ReviewId = model.ReviewId,
                    Content = model.Content,
                    CreatedUtc = DateTimeOffset.UtcNow
                };

            using (var ctx = new ApplicationDbContext())
            {
                entity.Game = ctx.Game.Find(model.GameId);
                ctx.Games.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<GameListItem> GetGamesByGameId(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Games
                        .Where(e => e.GameId == id && e.UserId == _userId)
                        .Select
                        (
                            e =>
                                new GameListItem
                                {
                                    ReactionId = e.ID,
                                    Content = e.Content,
                                    CreatedUtc = e.CreatedUtc
                                }
                        );

                return query.ToArray();
            }
        }

        public bool DeleteGame(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Games
                        .Single(e => e.ID == id && e.UserId == _userId);

                ctx.Games.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public bool UpdateGame(GameEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Games
                        .Single(e => e.ID == model.ReactionId && e.UserId == _userId);

                entity.Content = model.Content;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
