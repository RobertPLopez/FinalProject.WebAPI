using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProject.Data;

namespace FinalProject.Models
{
    public class ReactionListItem
    {
        public int ReactionId { get; set; }
        public React Content { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
