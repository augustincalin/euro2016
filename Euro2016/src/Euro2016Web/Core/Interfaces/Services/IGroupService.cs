using Euro2016Web.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Euro2016Web.Core.Interfaces.Services
{
    public interface IGroupService
    {
        ICollection<Group> GetGroups();
    }
}
