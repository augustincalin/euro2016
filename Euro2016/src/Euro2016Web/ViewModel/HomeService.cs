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
        private readonly IUserService _userService;
        private readonly IMatchService _matchService;
        private readonly IBetService _betService;
        private readonly IGroupService _groupService;
        public HomeService(IUserService userService, IMatchService matchService, IBetService betService, IGroupService groupService)
        {
            _userService = userService;
            _matchService = matchService;
            _betService = betService;
            _groupService = groupService;
        }
        public HomeViewModel GetHomeViewModel(string currentUsername, int? showForUserId)
        {
            DateTime nowDate = DateTime.Now;
            //DateTime nowDate = new DateTime(2016, 6,16);
            HomeViewModel viewModel = new HomeViewModel();
            User currentUser = _userService.GetUserByName(currentUsername);
            User userToShowFor = null;
            if (null == currentUser)
            {
                currentUser = _userService.Add(currentUsername);
            }

            userToShowFor = null != showForUserId ? _userService.GetUserById(showForUserId.GetValueOrDefault()) : currentUser;

            viewModel.Name = currentUser.FriendlyUsername ?? currentUser.Username;
            viewModel.Place = _userService.GetUserPosition(currentUser.Id);
            viewModel.TotalPoints = currentUser.TotalPoints.GetValueOrDefault();

            foreach (User u in _userService.GetTop(5))
            {
                viewModel.Top5Users.Add(new TopUserViewModel {Id = u.Id, Name = u.FriendlyUsername ?? u.Username, TotalPoints = u.TotalPoints.GetValueOrDefault() });
            }

            foreach (Match match in _matchService.GetPreviousMatches(nowDate))
            {
                AddMatch(viewModel.PreviousDays, userToShowFor, match);
            }

            foreach (Match match in _matchService.GetNextMatches(nowDate))
            {
                AddMatch(viewModel.NextDays, userToShowFor, match);
            }

            foreach(Group group in _groupService.GetGroups())
            {
                viewModel.Groups.Add(new GroupViewModel {
                    Id = group.Id,
                    Name = group.Name
                });
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

        public bool UpdateScore(int matchId, string userName, bool isOne, int value)
        {
            Bet bet = _betService.UpdateOrCreateBet(matchId, userName, isOne, value);
            return bet != null;
        }

        public void UpdateName(string userName, string name)
        {
            _userService.UpdateName(userName, name);
        }
    }
}
