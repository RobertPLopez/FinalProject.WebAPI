using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Data
{

    public class Game
    {
        [Key]
        public Guid GameID { get; set; } //Primary key for Game
        [Required]
        public Guid UserID { get; set; } //Application User's unique ID
        [Required]
        public string GameTitle { get; set; }
        [Required]
        public string DeveloperName { get; set; }
        [Required]
        public string Description { get; set; }

        public virtual List<Review> Reveiws{ get; set; } = new List<Review>();
        public double AverageRating
        { get
            {
                double totalAverageRating = 0;
                foreach (var rating in Reveiws)
                {
                    totalAverageRating += rating.Rating;
                }
                return Reveiws.Count > 0
                    ? Math.Round(totalAverageRating / Reveiws.Count, 2)
                    : 0;
            }
        }
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
