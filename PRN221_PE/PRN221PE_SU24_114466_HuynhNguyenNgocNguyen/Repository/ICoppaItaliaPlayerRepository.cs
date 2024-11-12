using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DataAccessObjects.CoppaItaliaPlayerDAO;

namespace Repository
{
    public interface ICoppaItaliaPlayerRepository
    {
        Task<List<CoppaItaliaPlayer>> GetList();
        Task<CoppaItaliaPlayerResponse> GetList(string searchTerm, int pageIndex, int pageSize);
        Task<CoppaItaliaPlayer> GetCoppaItaliaPlayerById(string id);
        Task AddPlayer(CoppaItaliaPlayer coppaItaliaPlayer);
        Task UpdatePlayer(CoppaItaliaPlayer coppaItaliaPlayer);
        Task DeletePlayer(string id);
    }
}
