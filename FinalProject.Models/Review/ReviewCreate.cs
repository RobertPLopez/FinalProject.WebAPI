using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class ReviewCreate
    {
        [Required]
        public string AuthorName { get; set; }
        [Required]
        [MaxLength(1000)]
        public string Content { get; set; }
        [Required]
        public double Rating { get; set; }
        [Required]
        public Guid GameID { get; set; }


    }
}
