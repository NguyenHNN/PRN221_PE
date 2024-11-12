using BusinessObjects;
using DataAccessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CoppaItaliaClubRepository : ICoppaItaliaClubRepository
    {
        public async Task<List<CoppaItaliaClub>> GetList()
        {
            return await CoppaItaliaPlayerDAO.Instance.GetCoppaItaliaClubs();
        }
    }
}
