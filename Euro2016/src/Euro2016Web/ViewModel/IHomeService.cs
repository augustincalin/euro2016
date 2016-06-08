using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Euro2016Web.ViewModel
{
    public interface IHomeService
    {
        HomeViewModel GetHomeViewModel(string currentUsername, int? showForUserId);
        bool UpdateScore(int matchId, string userName, bool isOne, int value);
        void UpdateName(string userName, string name);
    }
}
