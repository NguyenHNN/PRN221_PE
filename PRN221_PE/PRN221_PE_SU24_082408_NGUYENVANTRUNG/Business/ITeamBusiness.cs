using Data.Models;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public interface ITeamBusiness
    {
        Task<Pagination<Team>> GetTeam(string? i, string? n, int currentPage, int sizePage);
        Task<int> Create(Team team);
        Task<Team?> Getbyid(int id);
        Task<int> Remove(Team team);
        Task<int> Update(Team team);


    }
}
