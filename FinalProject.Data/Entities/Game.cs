using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Data.Entities
{
    public class Game
    {
        [Key]
        public int GameID { get; set; }
        [Required]
        public string DeveloperName { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
        [Required]
        public double AverageRating { get; set; }
        public int AgeOfPlayer { get; set; }
    }
}
