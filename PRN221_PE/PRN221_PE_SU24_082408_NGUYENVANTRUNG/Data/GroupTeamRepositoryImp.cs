using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class GroupTeamRepositoryImp : IGroupTeamRepository
    {
        private readonly Euro2024DbContext _dbContext;

        public GroupTeamRepositoryImp()
        {
            _dbContext =new Euro2024DbContext();
        }

        public async Task<List<GroupTeam>> GetAll()
        {
            return await _dbContext.GroupTeams.AsNoTracking().ToListAsync();
        }
    }
}
