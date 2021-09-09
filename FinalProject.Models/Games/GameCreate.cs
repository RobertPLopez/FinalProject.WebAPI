using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Models
{
   public class GameCreate
    {
        [Required]
        public Guid GameID { get; set; }
        [Required]
        [MaxLength(1000)]
        public string DeveloperName { get; set; }
        [Required]
        [MaxLength(5000)]
        public string Description { get; set; }
        [Required]
        public string GameTitle { get; set; }
    }
}
