using BusinessObjects;
using DataAccessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class TeamRepository : ITeamRepository
    {
        public Task<List<Team>> GetList()
        {
            return TeamDAO.Instance.GetList();
        }

        public Task<TeamDAO.TeamResponse> GetList(string searchTerm, int pageIndex, int pageSize)
        {
            return TeamDAO.Instance.GetList(searchTerm, pageIndex, pageSize);
        }

        public Task<Team> GetTeamById(int id)
        {
            return TeamDAO.Instance.GetTeamById(id);
        }

        public Task AddTeam(Team team)
        {
            return TeamDAO.Instance.AddPainting(team);
        }
        public Task UpdateTeam(Team team)
        {
            return TeamDAO.Instance.UpdateTeam(team);
        }
        public Task DeleteTeam(int id)
        {
            return TeamDAO.Instance.DeleteTeam(id);
        }
    }
}
