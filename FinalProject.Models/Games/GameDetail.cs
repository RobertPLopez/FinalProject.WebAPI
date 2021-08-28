using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class GameDetail
    {
        public Guid GameID { get; set; }
        public string DeveloperName { get; set; }
        public string Description { get; set; }
        [Display(Name = "Here is the game you chose")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}

