using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Euro2016Web.ViewModel
{
    public class UserViewModel
    {
        public string Name { get; set; }
        public int TotalPoints { get; set; }
        public int Place { get; set; }
        public List<DayViewModel> PreviousDays { get; set; }
        public List<DayViewModel> NextDays { get; set; }


        public UserViewModel()
        {
            PreviousDays = new List<DayViewModel>();
            NextDays = new List<DayViewModel>();
        }
    }
}
