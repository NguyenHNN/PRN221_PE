using BusinessObjects.Entities;
using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class SystemAccountDAO
    {
        private static SystemAccountDAO instance = null!;
        private static object objectLock = new object();   

        public static SystemAccountDAO Instance
        {
            get
            {
                lock(objectLock)
                {
                    if (instance == null)
                    {
                        instance = new SystemAccountDAO();
                    }
                    return instance;
                }
            }
        }

        public async Task<SystemAccount> GetAccountByEmailAsync(string accountEmail)
        {
            using (var context = new OilPaintingArt2024DbContext())
            {
                return await context.SystemAccounts.FirstOrDefaultAsync(x => 
                    x.AccountEmail != null &&
                    x.AccountEmail.Equals(accountEmail));
            }
        }
    }
}
