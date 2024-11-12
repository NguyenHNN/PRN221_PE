using BOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository;

public interface ITeamRepo
{
    Task<DAOs.TeamDAO.TeamResponse> getList(string searchTerm, int pageIndex, int pageSize);
    Task<Team> getTeamById(int id);

    Task RemoveTeam(int id);
}
