using BusinessObjects;
using DataAccessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Repository
{
    public class GroupTeamRepository : IGroupTeamRepository
    {
        public async Task<List<GroupTeam>> GetList()
        {
            return await TeamDAO.Instance.GetGroupTeams();
        }
    }
}
