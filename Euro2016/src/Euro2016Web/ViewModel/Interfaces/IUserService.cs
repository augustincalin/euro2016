using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Euro2016Web.ViewModel
{
    public interface IUserViewService
    {
        UserViewModel GetUserViewModel(int? userId, string userName);

    }
}
