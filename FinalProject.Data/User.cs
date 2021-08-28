using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Data
{
    public class User
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public Guid UserId { get; set; }
        [Required]
        public string UserName { get; set; }
    }
}
