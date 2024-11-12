using BusinessObjects.Entities;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class AccountRepository : IAccountRepository
    {
        public async Task<Account> GetByEmailAsync(string email)
            => await AccountDAO.Instance.GetByEmailAsync(email);
    }
}
