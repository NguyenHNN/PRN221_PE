using BOs;
using DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implement;

public class TeamRepo : ITeamRepo
{
    public async Task<TeamDAO.TeamResponse> getList(string searchTerm, int pageIndex, int pageSize)
    {
        return await TeamDAO.Instance.GetList(searchTerm, pageIndex, pageSize);
    }

    public async Task<Team> getTeamById(int id)
    {
        return await TeamDAO.Instance.GetTeamByID(id);
    }

    public async Task RemoveTeam(int id)
    {
        await TeamDAO.Instance.RemoveTeam(id);
    }
}
