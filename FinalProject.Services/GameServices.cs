using FinalProject.Data;
using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Services
{

    public class GameService
    {
        private readonly Guid _userID;

        public GameService(Guid userID)
        {
            _userID = userID;
        }

        public bool CreateGame(GameCreate model)
        {
            var entity =
                new Game()
                {
                    UserID = _userID,
                    GameTitle = model.GameTitle,
                    DeveloperName = model.DeveloperName,
                    Description = model.Description,
                    CreatedUtc = DateTimeOffset.Now
                };
            using (var ctx = new ApplicationDbContext())
            {

                ctx.Games.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public GameDetail GetGameById(Guid gameId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Games
                        .Single(e => e.GameID == gameId);
                return
                    new GameDetail
                    {
                        GameID = entity.GameID,
                        GameTitle = entity.GameTitle,
                        DeveloperName = entity.DeveloperName,
                        Description = entity.Description,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }
        public IEnumerable<GameListItem> GetAllGames()

        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Games
                        .Select
                        (
                            e =>
                                new GameListItem
                                {
                                    GameID = e.GameID,
                                    GameTitle = e.GameTitle,
                                    DeveloperName = e.DeveloperName,
                                    CreatedUtc = e.CreatedUtc
                                }
                        );
                return query.ToArray();
            }
        }

        public bool UpdateGame(GameEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                     ctx
                         .Games
                         .Single(e => e.GameID == model.GameID && e.UserID == _userID);

                entity.GameTitle = model.GameTitle;
                entity.DeveloperName = model.DeveloperName;
                entity.Description = model.Description;
                entity.CreatedUtc = model.CreatedUtc;
                entity.ModifiedUtc = model.ModifiedUtc;

                return ctx.SaveChanges() == 1;
            };
        }

        public bool DeleteGame(Guid GameID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Games
                        .Single(e => e.GameID == GameID && e.UserID == _userID);
                ctx.Games.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
