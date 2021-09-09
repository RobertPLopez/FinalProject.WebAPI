using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProject.Data;

namespace FinalProject.Models
{
    public class ReactionCreate
    {
        [Required]
        public int ReviewId { get; set; }

        [Required]
        [Range(0,4)]
        public React Content { get; set; }
    }
}
