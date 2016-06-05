using System;
using System.Collections.Generic;

namespace Euro2016Web.Core.Model
{
    public class Match : IEntity
    {
        public Match()
        {
            Bet = new HashSet<Bet>();
        }

        public int Id { get; set; }
        public int Team1Id { get; set; }
        public int Team2Id { get; set; }
        public DateTime StartDate { get; set; }
        public int MatchCategoryId { get; set; }
        public int? Score1 { get; set; }
        public int? Score2 { get; set; }
        public int GroupId { get; set; }
        public bool? IsPlaceholder { get; set; }

        public virtual ICollection<Bet> Bet { get; set; }
        public virtual MatchCategory MatchCategory { get; set; }
        public virtual Team Team1 { get; set; }
        public virtual Team Team2 { get; set; }
    }
}
