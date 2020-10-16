using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BoxingChampionshipWebApplication.Models
{
    public class Battle
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int AmountOfRounds { get; set; }
        public string BoxerOne { get; set; }
        public string BoxerTwo { get; set; }
        public int RefereePointsOne { get; set; }
        public int RefereePointsTwo { get; set; }
    }
}