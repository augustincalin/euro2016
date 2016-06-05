using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Euro2016Web.ViewModel
{
    public interface IHomeService
    {
        HomeViewModel GetHomeViewModel(string username);
    }
}
