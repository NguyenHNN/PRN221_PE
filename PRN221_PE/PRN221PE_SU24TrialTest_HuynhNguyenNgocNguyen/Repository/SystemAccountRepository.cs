using BusinessObjects;
using DataAccessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class SystemAccountRepository : ISystemAccountRepository
    {
        public async Task<SystemAccount>Login(string email,string password)
        {
            return await SystemAccountDAO.Instance.Login(email, password);
        }
    }
}
