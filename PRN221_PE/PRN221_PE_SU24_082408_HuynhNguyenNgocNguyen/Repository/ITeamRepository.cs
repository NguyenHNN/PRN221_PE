using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DataAccessObjects.TeamDAO;

namespace Repository
{
    public interface ITeamRepository
    {
        Task<List<Team>> GetList();
        Task<TeamResponse> GetList(string searchTerm, int pageIndex, int pageSize);
        Task<Team> GetTeamById(int id);
        Task AddTeam(Team team);
        Task UpdateTeam(Team team);
        Task DeleteTeam(int id);
    }
}
