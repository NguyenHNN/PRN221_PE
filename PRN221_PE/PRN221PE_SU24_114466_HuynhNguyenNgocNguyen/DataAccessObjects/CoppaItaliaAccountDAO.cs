using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects
{
    public class CoppaItaliaAccountDAO
    {
        private CoppaItalia2024DbContext _context;
        private static CoppaItaliaAccountDAO instance = null;

        private CoppaItaliaAccountDAO()
        {
            _context = new CoppaItalia2024DbContext();
        }

        public static CoppaItaliaAccountDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    return new CoppaItaliaAccountDAO();
                }
                return instance;
            }
        }

        public async Task<CoppaItaliaAccount> Login(string email, string password)
        {
            return await _context.CoppaItaliaAccounts.FirstOrDefaultAsync(acc => acc.EmailAddress == email && acc.AccPassword == password);
        }
    }
}
