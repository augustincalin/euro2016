using Euro2016Core.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Euro2016Core.Core.Interfaces
{
    public interface IMatchRepository:IRepository<Match>
    {
        IEnumerable<Match> GetPreviousMatches(DateTime dateTime);
        IEnumerable<Match> GetNextMatches(DateTime dateTime);
    }
}
