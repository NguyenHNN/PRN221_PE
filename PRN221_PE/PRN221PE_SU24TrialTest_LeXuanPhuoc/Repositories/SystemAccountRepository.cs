using BusinessObjects.Entities;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class SystemAccountRepository : ISystemAccountRepository
    {
        public async Task<SystemAccount> GetAccountByEmailAsync(string accountEmail)
            => await SystemAccountDAO.Instance.GetAccountByEmailAsync(accountEmail);
    }
}
