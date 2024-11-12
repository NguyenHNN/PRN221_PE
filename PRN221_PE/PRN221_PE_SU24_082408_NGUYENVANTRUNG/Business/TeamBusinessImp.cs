using Data;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class TeamBusinessImp : ITeamBusiness
    {
        private readonly ITeamRepository _teamRepository;

        public TeamBusinessImp()
        {
            _teamRepository =new TeamRepositoryImp();
        }

        public async Task<Pagination<Team>> GetTeam(string? i, string? n, int currentPage, int sizePage)
        {
            return await _teamRepository.GetAll(i, n, currentPage, sizePage);
        }

        public async Task<int> Create(Team team)
        {
            return await _teamRepository.Create(team);
        }
        public async Task<Team?> Getbyid(int id)
        {
            return await _teamRepository.GetById(id);
        }
        public async Task<int> Remove(Team team)
        {
            return await _teamRepository.Remove(team);
        }
        public async Task<int> Update(Team team)
        {
            return await _teamRepository.Update(team);
        }
    }
}
