using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Data
{
    public class Review
    {

        [Key]
        public int ReviewId { get; set; }
        [ForeignKey(nameof(Game))]
        public int GameID { get; set; }
        public virtual Game Game { get; set; }
        [Required]
        public string AuthorName { get; set; }
        public Guid AuthorId { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public double Rating { get; set; }
        [Required]
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
        




    }
}
