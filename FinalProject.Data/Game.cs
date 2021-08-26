using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Data
{
    public enum GameGenre
    {
        RPG,
        MMO,
        Text,
        "2D",
        "3D"
    }

    public class Game
    {
        [Key]
        public int GameID { get; set; }
        [Required]
        public string DeveloperName { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public GameGenre Genre { get; set; }
        [Required]
        public double AverageRating { get; set; }
        [Required]
        public int AgeOfPlayer { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
