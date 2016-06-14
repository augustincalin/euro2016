using System;
using System.Collections.Generic;

namespace Euro2016Core.Core.Model
{
    public class Team : IEntity
    {
        public Team()
        {
            MatchTeam1 = new HashSet<Match>();
            MatchTeam2 = new HashSet<Match>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Acronym { get; set; }
        public int GroupId { get; set; }
        public bool IsPlaceholder { get; set; }

        public virtual ICollection<Match> MatchTeam1 { get; set; }
        public virtual ICollection<Match> MatchTeam2 { get; set; }
        public virtual Group Group { get; set; }
    }
}
