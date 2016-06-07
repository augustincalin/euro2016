using Euro2016Web.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Euro2016Web.Core.Model;
using Euro2016Web.Core.Interfaces;

namespace Euro2016Web.Core.Services
{
    public class BetService : IBetService
    {
        protected readonly IRepository<Bet> _betRepository;
        protected readonly IUserService _userService;
        public BetService(IRepository<Bet> betRepository, IUserService userService)
        {
            _betRepository = betRepository;
            _userService = userService;
        }
        public Bet UpdateOrCreateBet(int matchId, string userName, bool isOne, int value)
        {
            User user = _userService.GetUserByName(userName);
            Bet existingBet = null;

            if (null != user)
            {
                existingBet = _betRepository.Find(b => b.MatchId == matchId && b.UserId == user.Id).FirstOrDefault();

                if (null == existingBet)
                {
                    existingBet = new Bet
                    {
                        MatchId = matchId,
                        UserId = user.Id,
                        PointsGained = 0
                    };
                    _betRepository.Add(existingBet);
                }

                if (isOne)
                {
                    existingBet.Score1 = value;
                }
                else
                {
                    existingBet.Score2 = value;
                }

                _betRepository.Save();
            }
            return existingBet;
        }
    }
}
