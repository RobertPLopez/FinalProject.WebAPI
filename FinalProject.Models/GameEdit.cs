﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public enum GameGenre
    {
        RPG,
        MMO,
        Text,
    }
    public class GameEdit
    {
        public int GameID { get; set; }
        public string DeveloperName { get; set; }

        public string Description { get; set; }

        public GameGenre Genre { get; set; }

        public double AverageRating { get; set; }

        public int AgeOfPlayer { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}

