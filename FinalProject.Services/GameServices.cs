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
        public bool CreateGame (GameCreate model)
        {
            var entity =
                new Game()
                {
                    GameID = model.GameID,
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

        public GameDetail GetGamesById (int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Games
                        .Single(e => e.GameID == id);
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
        public IEnumerable<GameListItem> GetGamesByGameId(int id)

        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Games
                        .Where(e => e.GameID == id)
                        .Select
                        (
                            e =>
                                new GameListItem
                                {
                                    GameID = e.GameID,
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
                         .Single(e => e.GameID == model.GameID);

                    entity.GameID = model.GameID;
                    entity.GameTitle = model.GameTitle;
                    entity.DeveloperName = model.DeveloperName;
                    entity.Description = model.Description;
                    entity.AverageRating = model.AverageRating;
                    entity.AgeOfPlayer = model.AgeOfPlayer;
                    entity.CreatedUtc = model.CreatedUtc;
                    entity.ModifiedUtc = model.ModifiedUtc;

                    return ctx.SaveChanges() == 1;
            };
        }

        public bool DeleteGame(int gameID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Games
                        .Single(e => e.GameID == gameID);
                ctx.Games.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
