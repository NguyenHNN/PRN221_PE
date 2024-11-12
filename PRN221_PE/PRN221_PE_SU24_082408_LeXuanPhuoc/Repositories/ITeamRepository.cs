using BusinessObjects.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface ITeamRepository
    {
        Task<List<Team>> GetTeamsAsync();
        Task<List<Team>> SearchAsync(string searchValue);
        Task<Team> GetByIdAsync(int id);
        Task<bool> CreateAsync(Team team);
        Task UpdateAsync(Team team);
        Task<bool> DeleteAsync(int id);
    }
}
