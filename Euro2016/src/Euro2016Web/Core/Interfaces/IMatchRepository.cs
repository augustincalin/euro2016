using Euro2016Web.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Euro2016Web.Core.Interfaces
{
    public interface IMatchRepository:IRepository<Match>
    {
        IEnumerable<Match> GetPreviousMatches(DateTime dateTime);
        IEnumerable<Match> GetNextMatches(DateTime dateTime);
    }
}
