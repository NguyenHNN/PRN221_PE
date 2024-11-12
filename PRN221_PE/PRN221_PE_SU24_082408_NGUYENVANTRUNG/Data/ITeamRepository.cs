using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface ITeamRepository
    {
        Task<Pagination<Team>> GetAll(string? i, string? t, int currenpage, int pageSize);
        Task<int> Create(Team oilPaintingArt);
        Task<Team?> GetById(int id);
         Task<int> Remove(Team team);
        Task<int> Update(Team team);



    }
}
