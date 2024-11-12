using BusinessObjects.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class AccountDAO
    {

        private static AccountDAO instance = null!;
        private static object objectLock = new object();

        public static AccountDAO Instance
        {
            get
            {
                lock (objectLock)
                {
                    if (instance == null)
                    {
                        instance = new AccountDAO();
                    }
                    return instance;
                }
            }
        }


        public async Task<Account> GetByEmailAsync(string email)
        {
            using(var context = new Euro2024DbContext())
            {
                return await context.Accounts.FirstOrDefaultAsync(x => x.Email == email);
            }
        }

    }
}
