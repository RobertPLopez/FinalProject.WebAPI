using FinalProject.Data;
using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Services
{
    public class GameServices
    {
        private readonly Guid _userId;

        public GameServices(Guid userId)
        {
            _userId = userId;
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
    }
}
