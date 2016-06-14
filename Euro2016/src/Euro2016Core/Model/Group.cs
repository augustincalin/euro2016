using System;
using System.Collections.Generic;

namespace Euro2016Core.Core.Model
{
    public class Group : IEntity
    {
        public Group()
        {
            Team = new HashSet<Team>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string ExternalGroupId { get; set; }

        public virtual ICollection<Team> Team { get; set; }
    }
}
