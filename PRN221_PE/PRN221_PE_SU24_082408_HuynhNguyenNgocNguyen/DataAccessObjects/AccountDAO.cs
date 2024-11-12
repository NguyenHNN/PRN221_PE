using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects
{
    public class AccountDAO
    {
        private Euro2024DbContext _context;
        private static AccountDAO instance = null ;
        private AccountDAO() 
        {
        _context = new Euro2024DbContext();
        }
        public static AccountDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    return new AccountDAO();
                }
                return instance;
            }
        }

        public async Task<Account> Login(string email, string password)
        {
            return await _context.Accounts.FirstOrDefaultAsync(acc => acc.Email == email && acc.Password == password);
        }
    }
}
