using Euro2016Web.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Euro2016Web.Core.Model;
using Euro2016Web.Core.Interfaces;

namespace Euro2016Web.Core.Services
{
    public class GroupService : IGroupService
    {
        protected readonly IRepository<Group> _repositoryGroup;
        public GroupService(IRepository<Group> repositoryGroup)
        {
            _repositoryGroup = repositoryGroup;
        }
        public ICollection<Group> GetGroups()
        {
            return _repositoryGroup.GetAll().OrderBy(g => g.Id).ToList();
        }
    }
}
