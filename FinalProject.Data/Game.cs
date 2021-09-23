﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Data
{
    public enum GameGenre
    {
        RPG,
        MMO,
        Text,
    }

    public class Game
    {
        [Key]
        public Guid GameID { get; set; } //Primary key for Game
        [Required]
        public Guid UserID { get; set; } //Application User's unique ID
        [Required]
        public string GameTitle { get; set; }
        [Required]
        public string DeveloperName { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public GameGenre Genre { get; set; }
        [Required]
        public double AverageRating { get; }
        [Required]
        public int AgeOfPlayer { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
