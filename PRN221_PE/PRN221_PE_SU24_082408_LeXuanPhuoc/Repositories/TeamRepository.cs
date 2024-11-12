using BusinessObjects.Entities;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class TeamRepository : ITeamRepository
    {
        public async Task<bool> CreateAsync(Team team)
            => await TeamDAO.Instance.CreateAsync(team);

        public async Task<bool> DeleteAsync(int id)
            => await TeamDAO.Instance.DeleteAsync(id);

        public async Task<Team> GetByIdAsync(int id)
            => await TeamDAO.Instance.GetByIdAsync(id);

        public async Task<List<Team>> GetTeamsAsync()
            => await TeamDAO.Instance.GetTeamsAsync();

        public async Task<List<Team>> SearchAsync(string searchValue)
            => await TeamDAO.Instance.SearchAsync(searchValue);

        public async Task UpdateAsync(Team team)
            => await TeamDAO.Instance.UpdateAsync(team);
    }
}
