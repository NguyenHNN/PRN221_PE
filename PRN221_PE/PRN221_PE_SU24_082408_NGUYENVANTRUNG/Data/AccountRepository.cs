using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class AccountRepository : IAccountRepository
    {
        private readonly Euro2024DbContext _dbContext;

        public AccountRepository()
        {
            _dbContext = new Euro2024DbContext();
        }

        public async Task<Account?> Authentication(string email, string password)
        {
            return await _dbContext.Accounts.FirstOrDefaultAsync(x => x.Email == email
                                                               && x.Password == password && x.Status == "active");
        }
    }
}
