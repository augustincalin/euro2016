using Euro2016Web.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Euro2016Web.Core.Model;
using Euro2016Web.Core.Interfaces;

namespace Euro2016Web.Core.Services
{
    public class MatchService : IMatchService
    {
        protected IMatchRepository _matchRepository;
        public MatchService(IMatchRepository matchRepository)
        {
            _matchRepository = matchRepository;
        }
        public IEnumerable<Match> GetNextMatches(DateTime dateTime)
        {

            return _matchRepository.GetNextMatches(dateTime);
        }

        public IEnumerable<Match> GetPreviousMatches(DateTime dateTime)
        {
            return _matchRepository.GetPreviousMatches(dateTime);
        }

        public bool IsMatchBetable(int matchId, DateTime dateTime)
        {
            Match matchToBetTo = _matchRepository.Find(m => m.Id == matchId && m.StartDate >= dateTime).SingleOrDefault();
            return null != matchToBetTo;

        }
    }
}
