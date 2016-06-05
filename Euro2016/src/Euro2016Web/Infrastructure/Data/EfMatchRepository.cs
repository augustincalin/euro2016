using Euro2016Web.Core.Interfaces;
using Euro2016Web.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Euro2016Web.Model;

namespace Euro2016Web.Infrastructure.Data
{
    public class EfMatchRepository : EfRepository<Match>, IMatchRepository
    {
        public EfMatchRepository(EURO2016DBContext context) : base(context)
        {
        }

        public IEnumerable<Match> GetNextMatches(DateTime dateTime)
        {
            return EURO2016DBContext.Match.Include(m => m.Team1).Include(m => m.Team2).Include(m=>m.Bet).Where(m => m.StartDate >= dateTime).OrderBy(m => m.StartDate);
        }

        public IEnumerable<Match> GetPreviousMatches(DateTime dateTime)
        {
            return EURO2016DBContext.Match.Include(m => m.Team1).Include(m => m.Team2).Include(m=>m.Bet).Where(m => m.StartDate < dateTime).OrderBy(m => m.StartDate);
        }

        public EURO2016DBContext EURO2016DBContext
        {
            get { return Context as EURO2016DBContext; }
        }
    }
}
