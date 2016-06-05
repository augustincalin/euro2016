using System;

namespace Euro2016Web.ViewModel
{
    public class MatchViewModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Team1 { get; set; }
        public string Team2 { get; set; }
        public string Acronym1 { get; set; }
        public string Acronym2 { get; set; }
        public int? Score1 { get; set; }
        public int? Score2 { get; set; }
        public int? Guess1 { get; set; }
        public int? Guess2 { get; set; }
        public int? PointsGained { get; set; }
        public bool IsPlaceholder { get; set; }

    }
}