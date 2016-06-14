using Euro2016Core.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Euro2016Core.Core.Interfaces.Services
{
    public interface IBetService
    {
        Bet UpdateOrCreateBet(int matchId, string userName, bool isOne, int value);
    }
}
