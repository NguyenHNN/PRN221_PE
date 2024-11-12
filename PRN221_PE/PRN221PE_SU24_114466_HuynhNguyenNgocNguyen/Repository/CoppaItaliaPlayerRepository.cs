using BusinessObjects;
using DataAccessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CoppaItaliaPlayerRepository : ICoppaItaliaPlayerRepository
    {
        public Task<List<CoppaItaliaPlayer>> GetList()
        {
            return CoppaItaliaPlayerDAO.Instance.GetList();
        }

        public Task<CoppaItaliaPlayerDAO.CoppaItaliaPlayerResponse> GetList(string searchTerm, int pageIndex, int pageSize)
        {
            return CoppaItaliaPlayerDAO.Instance.GetList(searchTerm, pageIndex, pageSize);
        }

        public Task<CoppaItaliaPlayer> GetCoppaItaliaPlayerById(string id)
        {
            return CoppaItaliaPlayerDAO.Instance.GetCoppaItaliaPlayerById(id);
        }

        public Task AddPlayer(CoppaItaliaPlayer coppaItaliaPlayer)
        {
            return CoppaItaliaPlayerDAO.Instance.AddPlayer(coppaItaliaPlayer);
        }
        public Task UpdatePlayer(CoppaItaliaPlayer coppaItaliaPlayer)
        {
            return CoppaItaliaPlayerDAO.Instance.UpdatePlayer(coppaItaliaPlayer);
        }
        public Task DeletePlayer(string id)
        {
            return CoppaItaliaPlayerDAO.Instance.DeletePlayer(id);
        }
    }
}
