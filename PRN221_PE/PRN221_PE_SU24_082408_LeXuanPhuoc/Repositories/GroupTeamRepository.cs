using BusinessObjects.Entities;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class GroupTeamRepository : IGroupTeamRepository
    {
        public async Task<List<GroupTeam>> GetGroupTeamsAsync()
            => await GroupTeamDAO.Instance.GetGroupTeamsAsync();
    }
}
