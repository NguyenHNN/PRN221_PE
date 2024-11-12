using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class TeamRepositoryImp : ITeamRepository
    {
        private readonly Euro2024DbContext _dbContext;

        public TeamRepositoryImp()
        {
            _dbContext = new Euro2024DbContext();   
        }

        public async Task<int> Create(Team team)
        {
            await _dbContext.AddAsync(team);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<Pagination<Team>> GetAll(string? i, string? t, int currenpage, int pageSize)
        {
            IQueryable<Team> query = _dbContext.Teams.Include(x => x.Group);

            if (!string.IsNullOrWhiteSpace(i))
            {
                var styleLower = i.ToLower().Trim();
                query = query.Where(x => x.Position != null && x.Position.Equals(styleLower));
            }

            if (!string.IsNullOrWhiteSpace(t))
            {
                var artistLower = t.ToLower().Trim();
                query = query.Where(x => x.Group.GroupName != null && x.Group.GroupName.ToLower().Contains(artistLower));
            }
            var totalItems = await query.CountAsync();

            return await Pagination<Team>.Create(query, currenpage, pageSize, totalItems);
        }

        public async Task<Team?> GetById(int id)
        {
            return await _dbContext.Teams.AsNoTracking().Include(x => x.Group).SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<int> Remove(Team team)
        {
            _dbContext.Remove(team);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> Update(Team team)
        {
            _dbContext.Update(team);
            return await _dbContext.SaveChangesAsync();
        }
    }
}
