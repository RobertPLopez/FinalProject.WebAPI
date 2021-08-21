using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Data
{
    public enum React
    {
        Positive,
        Negative,
        Professional,
        Ammateur,
        Funny
    }

    public class Reaction
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [ForeignKey(nameof(Review))]
        public int ReviewId { get; set; }
        public virtual Review Review { get; set; }

        [Required]
        [Display(Name = "Reaction")]
        [Range(0,4)]
        public React Content { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
