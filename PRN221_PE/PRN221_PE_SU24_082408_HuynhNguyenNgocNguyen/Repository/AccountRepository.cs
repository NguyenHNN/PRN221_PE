using BusinessObjects;
using DataAccessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class AccountRepository : IAccountRepository
    {
        public async Task<Account> Login(string email, string password)
        {
            return await AccountDAO.Instance.Login(email, password);
        }
    }
}
