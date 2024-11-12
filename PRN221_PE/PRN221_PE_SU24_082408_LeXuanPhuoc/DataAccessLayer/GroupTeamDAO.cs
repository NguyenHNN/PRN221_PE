using BusinessObjects.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class GroupTeamDAO
    {

        private static GroupTeamDAO instance = null!;
        private static object objectLock = new object();

        public static GroupTeamDAO Instance
        {
            get
            {
                lock (objectLock)
                {
                    if (instance == null)
                    {
                        instance = new GroupTeamDAO();
                    }
                    return instance;
                }
            }
        }

        public async Task<List<GroupTeam>> GetGroupTeamsAsync()
        {
            using(var context = new Euro2024DbContext())
            {
                return await context.GroupTeams.ToListAsync();
            }
        }

    }
}
