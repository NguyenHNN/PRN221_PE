using BusinessObjects;
using DataAccessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CoppaItaliaAccountRepository : ICoppaItaliaAccountRepository
    {
        public async Task<CoppaItaliaAccount> Login(string email, string password)
        {
            return await CoppaItaliaAccountDAO.Instance.Login(email, password);
        }
    }
}
