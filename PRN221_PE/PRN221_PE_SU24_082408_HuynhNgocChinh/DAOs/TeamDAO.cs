using BOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAOs;

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
            query = query.Where(x => x.Position.ToString().Equals(searchTerm) || x.Group.GroupName.ToLower().Contains(searchTerm.ToLower()));
        }

        int count = query.Count(); //11
        int totalPages = (int)Math.Ceiling(count / (double)pageSize); //3

        query = query.Skip((pageIndex - 1) * pageSize).Take(pageSize);

        return new TeamResponse
        {
            Teams = await query.ToListAsync(),
            TotalPages = totalPages,
            PageIndex = pageIndex
        };
    }

    public async Task<Team> GetTeamByID(int id)
    {
        var team = await _context.Teams.FirstOrDefaultAsync(m => m.Id == id);
        return team;
    }

    public async Task RemoveTeam(int id)
    {
        var team = await _context.Teams.FirstOrDefaultAsync(m => m.Id == id);

        _context.Teams.Remove(team);
        _context.SaveChanges();
    }
}
