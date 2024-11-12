using BusinessObjects.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class TeamDAO
    {

        private static TeamDAO instance = null!;
        private static object objectLock = new object();

        public static TeamDAO Instance
        {
            get
            {
                lock (objectLock)
                {
                    if (instance == null)
                    {
                        instance = new TeamDAO();
                    }
                    return instance;
                }
            }
        }


        public async Task<List<Team>> GetTeamsAsync()
        {
            using (var context = new Euro2024DbContext())
            {
                return await context.Teams.Include(x => x.Group).ToListAsync();
            }
        }

        public async Task<List<Team>> SearchAsync(string searchValue)
        {
            using (var context = new Euro2024DbContext())
            {
                if(int.TryParse(searchValue, out var validNum))
                {
                    return await context.Teams.Where(x => x.Position == validNum).ToListAsync();
                }

                return await context.Teams.Include(x => x.Group).Where(x => 
                    x.Group.GroupName.ToLower().Contains(searchValue.ToLower())).ToListAsync();
            }
        }

        public async Task<Team> GetByIdAsync(int id)
        {
            using (var context = new Euro2024DbContext())
            {
                return await context.Teams.FirstOrDefaultAsync(x => x.Id == id) ?? null!;
            }
        }

        public async Task<bool> CreateAsync(Team team)
        {
            using (var context = new Euro2024DbContext())
            {
                await context.Teams.AddAsync(team);
                return await context.SaveChangesAsync() > 0;
            }
        }

        public async Task UpdateAsync(Team team)
        {
            using (var context = new Euro2024DbContext())
            {
                var existingTeam = await context.Teams.FirstOrDefaultAsync(x => x.Id == team.Id);

                if (existingTeam != null)
                {
                    // Update fields
                    existingTeam.TeamName = team.TeamName;
                    existingTeam.Point = team.Point;
                    existingTeam.GroupId = team.GroupId;
                    existingTeam.Position = team.Position;

                    context.Teams.Update(existingTeam);
                    await context.SaveChangesAsync();
                }
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            using (var context = new Euro2024DbContext())
            {
                var existingTeam = await context.Teams.FirstOrDefaultAsync(x =>
                    x.Id == id);

                if (existingTeam != null)
                {
                    existingTeam.Group = null;
                    context.Teams.Remove(existingTeam);
                    return await context.SaveChangesAsync() > 0;
                }

                return false;
            }
        }

    }
}
