using System;
using System.Collections.Generic;

namespace Euro2016Core.Core.Model
{
    public class User : IEntity
    {
        public User()
        {
            Bet = new HashSet<Bet>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string FriendlyUsername { get; set; }
        public int? TotalPoints { get; set; }

        public virtual ICollection<Bet> Bet { get; set; }
    }
}
