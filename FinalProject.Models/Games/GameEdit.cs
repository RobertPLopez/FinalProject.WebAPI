using FinalProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class GameEdit
    {
        public Guid GameID { get; set; }
        public string GameTitle { get; set; }
        public string DeveloperName { get; set; }
        public string Description { get; set; }
        public GameGenre Genre { get; set; }
        public double AverageRating { get; set; }
        public int AgeOfPlayer { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}