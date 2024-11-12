using BOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAOs;

public class GroupTeamDAO
{
    private readonly Euro2024DbContext _context;
    private static GroupTeamDAO instance = null;

    private GroupTeamDAO()
    {
        _context = new Euro2024DbContext();
    }

    public static GroupTeamDAO Instance
    {
        get
        {
            if (instance == null)
            {
                return new GroupTeamDAO();
            }
            return instance;
        }
    }


    public async Task<List<GroupTeam>> GetGroupTeams()
    {
        var groupTeams = await _context.GroupTeams.ToListAsync();
        return groupTeams;
    }
   
}
