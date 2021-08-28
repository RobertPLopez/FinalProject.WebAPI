﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class GameListItem
    {
        public int GameID { get; set; }
        public string DeveloperName { get; set; }	
        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}

