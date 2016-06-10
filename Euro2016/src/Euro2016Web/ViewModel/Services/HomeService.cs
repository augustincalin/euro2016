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

            HomeViewModel viewModel = new HomeViewModel();

            User currentUser = _userService.GetUserByName(currentUsername);           
            if (null == currentUser)
            {
                currentUser = _userService.Add(currentUsername);
            }

            viewModel.Name = currentUser.FriendlyUsername ?? currentUser.Username;
            viewModel.Place = _userService.GetUserPosition(currentUser.Id);
            viewModel.TotalPoints = currentUser.TotalPoints.GetValueOrDefault();

            foreach (User u in _userService.GetTop(5))
            {
                viewModel.Top5Users.Add(new TopUserViewModel {Id = u.Id, Name = u.FriendlyUsername ?? u.Username, TotalPoints = u.TotalPoints.GetValueOrDefault() });
            }

            foreach(Group group in _groupService.GetGroups())
            {
                viewModel.Groups.Add(new GroupViewModel {
                    Id = group.Id,
                    Name = group.Name,
                    ExternalGroupId = group.ExternalGroupId
                });
            }

            return viewModel;
        }

        

        private int? GetPointsGained(Bet bet)
        {
            return bet == null ? null : bet.PointsGained;
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
