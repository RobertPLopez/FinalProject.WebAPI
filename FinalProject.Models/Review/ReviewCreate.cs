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
        public string AuthorName { get; set; }

        [MaxLength(1000)]
        public string Content { get; set; }
        public double Rating { get; set; }

        public Guid GameID { get; set; }


    }
}
