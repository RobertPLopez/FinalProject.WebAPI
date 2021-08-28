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
        public Guid GameID { get; set; }
        public virtual Game Game { get; set; }
/*        [ForeignKey(nameof(Author))]
        public Guid AuthorId { get; set; }
        public virtual Author Author { get; set; }*/
        [Required]
        public string AuthorName { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public double Rating { get; set; }
        [Required]
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
        




    }
}
