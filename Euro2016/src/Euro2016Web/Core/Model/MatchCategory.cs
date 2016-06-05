using System;
using System.Collections.Generic;

namespace Euro2016Web.Core.Model
{
    public class MatchCategory : IEntity
    {
        public MatchCategory()
        {
            Match = new HashSet<Match>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Match> Match { get; set; }
    }
}
