using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Euro2016Web.ViewModel
{
    public class HomeViewModel
    {
        public string Name { get; set; }
        public int TotalPoints { get; set; }
        public int Place { get; set; }
        public List<TopUserViewModel> Top5Users { get; set; }
        public List<GroupViewModel> Groups { get; set; }
        public List<DayViewModel> PreviousDays { get; set; }
        public List<DayViewModel> NextDays { get; set; }

        public HomeViewModel()
        {
            Top5Users = new List<TopUserViewModel>();
            Groups = new List<GroupViewModel>();
            PreviousDays = new List<DayViewModel>();
            NextDays = new List<DayViewModel>();
        }
    }
}
