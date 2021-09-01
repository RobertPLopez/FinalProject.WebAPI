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
        private readonly int _gameID;

        public GameService(int gameID)
        {
            _gameID = gameID;
        }

        public bool CreateGame (GameCreate model)

        {
            var entity =
                new Game()
                {
                    GameID = _gameID,
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
                        .Single(e => e.GameID == id && e.GameID == _gameID);
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

                        .Where(e => e.GameID == id && e.GameID == _gameID)

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
                         .Single(e => e.GameID == model.GameID && e.GameID == _gameID);

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

        public bool DeleteGame(int GameID)

        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Games

                        .Single(e => e.GameID == GameID && e.GameID == _gameID);
                ctx.Games.Remove(entity);


                return ctx.SaveChanges() == 1;
            }
        }
    }
}
