using System;
using System.Collections.Generic;

namespace Euro2016Web.ViewModel
{
    public class DayViewModel
    {
        public DateTime Date { get; set; }
        public List<MatchViewModel> Matches { get; set; }
        public DayViewModel()
        {
            Matches = new List<MatchViewModel>();
        }
    }
}