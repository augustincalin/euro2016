using System;
using System.Collections.Generic;

namespace Euro2016Core.Core.Model
{
    public class Bet : IEntity
    {
        public int Id { get; set; }
        public int MatchId { get; set; }
        public int UserId { get; set; }
        public int? Score1 { get; set; }
        public int? Score2 { get; set; }

        public int? PointsGained { get; set; }

        public virtual Match Match { get; set; }
        public virtual User User { get; set; }
    }
}
