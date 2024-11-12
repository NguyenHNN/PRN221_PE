using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects
{
    public class TeamDAO
    {
        private readonly Euro2024DbContext _context;
        private static TeamDAO instance = null;

        private TeamDAO()
        {
            _context = new Euro2024DbContext();
        }
        public static TeamDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    return new TeamDAO();
                }
                return instance;
            }
        }
        public async Task<List<Team>> GetList()
        {
            return await _context.Teams.Include(x => x.Group).ToListAsync();
        }
        public class TeamResponse
        {
            public List<Team> Teams { get; set; }
            public int TotalPages { get; set; }
            public int PageIndex { get; set; }
        }
        public async Task<TeamResponse> GetList(string searchTerm, int pageIndex, int pageSize)
        {
            var query = _context.Teams.Include(x => x.Group).AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                query = query.Where(x =>
            x.Position.ToString().Contains(searchTerm) ||
            (x.Group != null && x.Group.GroupName != null && x.Group.GroupName.ToLower().Contains(searchTerm.ToLower())));
            }

            int count = await query.CountAsync(); //11
            int totalPages = (int)Math.Ceiling(count / (double)pageSize); //3

            query = query.Skip((pageIndex - 1) * pageSize).Take(pageSize);

            return new TeamResponse
            {
                Teams = await query.ToListAsync(),
                TotalPages = totalPages,
                PageIndex = pageIndex
            };
        }
        public async Task<Team> GetTeamById(int id)
        {
            return await _context.Teams.Include(x => x.Group).FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task AddPainting(Team team)
        {
            try
            {
                var existingArt = await GetTeamById(team.Id);
                if (existingArt != null)
                {
                    throw new Exception("Art already exists");
                }
                _context.Teams.Add(team);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task UpdateTeam(Team team)
        {
            try
            {
                var existingTeam = await GetTeamById(team.Id);
                if (existingTeam == null)
                {
                    throw new Exception("Does not exist");
                }

                existingTeam.TeamName = team.TeamName;
                existingTeam.Point = team.Point;
                existingTeam.Position = team.Position;
                var group = await _context.GroupTeams.FirstOrDefaultAsync(s => s.GroupId == team.GroupId);
                if (group == null)
                {
                    throw new Exception("Group does not exist");
                }
                existingTeam.GroupId = team.GroupId;

                _context.Teams.Update(existingTeam);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task DeleteTeam(int id)
        {
            try
            {
                var existTeam = _context.Teams.FirstOrDefault(m => m.Id == id);
                if (existTeam == null)
                {
                    throw new Exception("Team not found");
                }
                _context.Teams.Remove(existTeam);
                await _context.SaveChangesAsync();

            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public async Task<List<GroupTeam>> GetGroupTeams()
        {
            return await _context.GroupTeams.ToListAsync();
        }
    }
}
