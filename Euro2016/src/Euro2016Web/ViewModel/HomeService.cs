using Euro2016Web.Core.Interfaces.Services;
using Euro2016Web.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Euro2016Web.ViewModel
{
    public class HomeService : IHomeService
    {
        protected readonly IUserService _userService;
        protected readonly IMatchService _matchService;
        public HomeService(IUserService userService, IMatchService matchService)
        {
            _userService = userService;
            _matchService = matchService;
        }
        public HomeViewModel GetHomeViewModel(string username)
        {
            HomeViewModel viewModel = new HomeViewModel();
            User currentUser = _userService.GetUserByName(username);
            if(null == currentUser)
            {
                currentUser = _userService.Add(username);
            }
            viewModel.Name = currentUser.FriendlyUsername ?? currentUser.Username;
            viewModel.Place = 123;
            viewModel.TotalPoints = currentUser.TotalPoints.GetValueOrDefault();

            foreach (User u in _userService.GetTop(5))
            {
                viewModel.Top5Users.Add(new TopUserViewModel { Name = u.FriendlyUsername??u.Username, TotalPoints=u.TotalPoints.GetValueOrDefault()});
            }

            foreach(Match match in _matchService.GetPreviousMatches(DateTime.Now))
            {
                AddMatch(viewModel.PreviousDays, currentUser, match);
            }

            foreach (Match match in _matchService.GetNextMatches(DateTime.Now))
            {
                AddMatch(viewModel.NextDays, currentUser, match);
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

        private int? GetPointsGained(Bet bet)
        {
            return bet == null ? null : bet.PointsGained;
        }

        private int? GetGuess(Bet b, bool bet1)
        {
            return b == null ? null : bet1 ? b.Score1 : b.Score2;
        }
    }
}
