using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects
{
    public class SystemAccountDAO
    {
        private OilPaintingArt2024DbContext _context;
        private static SystemAccountDAO instance = null;

        private SystemAccountDAO() 
        {
            _context = new OilPaintingArt2024DbContext();
        }

        public static SystemAccountDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    return new SystemAccountDAO();
                }    
                return instance;
            }
        }

        public async Task<SystemAccount> Login(string email, string password)
        {
            return await _context.SystemAccounts.FirstOrDefaultAsync(acc => acc.AccountEmail == email && acc.AccountPassword == password);
        }

    }
}
