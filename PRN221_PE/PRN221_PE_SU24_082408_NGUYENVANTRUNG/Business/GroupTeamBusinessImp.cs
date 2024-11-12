using Data;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Business
{
    public class GroupTeamBusinessImp : IGroupTeamBusiness
    {
        private readonly IGroupTeamRepository _groupTeam;
        public GroupTeamBusinessImp()
        {
            _groupTeam = new GroupTeamRepositoryImp();
        }
        public async Task<List<GroupTeam>> GetAll()
        {
            return await _groupTeam.GetAll();
        }
    }
}
