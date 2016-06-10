using Euro2016Web.Core.Interfaces.Services;
using Euro2016Web.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Euro2016Web.ViewModel
{
    public class UserViewService : IUserViewService
    {
        private readonly IUserService _userService;
        private readonly IMatchService _matchService;
        public UserViewService(IUserService userService, IMatchService matchService)
        {
            _userService = userService;
            _matchService = matchService;
        }
        public UserViewModel GetUserViewModel(int userId)
        {
            DateTime nowDate = DateTime.Now;
            //DateTime nowDate = new DateTime(2016, 6, 16);
            UserViewModel viewModel = new UserViewModel();
            User currentUser = _userService.GetUserById(userId);


            viewModel.Name = currentUser.FriendlyUsername ?? currentUser.Username;
            viewModel.Place = 123;
            viewModel.TotalPoints = currentUser.TotalPoints.GetValueOrDefault();

            foreach (Match match in _matchService.GetPreviousMatches(nowDate))
            {
                AddMatch(viewModel.PreviousDays, currentUser, match);
            }


            return viewModel;
        }

        private void AddMatch(List<DayViewModel> listOfMatches, User currentUser, Match m)
        {
            DayViewModel dvm;
            DateTime whenDate = new DateTime(m.StartDate.Year, m.StartDate.Month, m.StartDate.Day);
            dvm = listOfMatches.FirstOrDefault(pd => pd.Date == whenDate) ?? new DayViewModel { Date = whenDate };
            dvm.Matches.Add(new MatchViewModel
            {
                Id = m.Id,
                Date = m.StartDate,
                IsPlaceholder = m.IsPlaceholder.GetValueOrDefault(),
                Team1 = m.Team1.Name,
                Team2 = m.Team2.Name,
                Acronym1 = m.Team1.Acronym,
                Acronym2 = m.Team2.Acronym,
                Guess1 = GetGuess(m.Bet.FirstOrDefault(b => b.MatchId == m.Id && b.UserId == currentUser.Id), true),
                Guess2 = GetGuess(m.Bet.FirstOrDefault(b => b.MatchId == m.Id && b.UserId == currentUser.Id), false),
                PointsGained = GetPointsGained(m.Bet.FirstOrDefault(b => b.MatchId == m.Id && b.UserId == currentUser.Id)),
                Score1 = m.Score1,
                Score2 = m.Score2

            });

            if (!listOfMatches.Any(pd => pd.Date == whenDate))
            {
                listOfMatches.Add(dvm);
            }
        }

        private int? GetGuess(Bet b, bool bet1)
        {
            return b == null ? null : bet1 ? b.Score1 : b.Score2;
        }

        private int? GetPointsGained(Bet bet)
        {
            return bet == null ? null : bet.PointsGained;
        }




    }
}
