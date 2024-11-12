using BOs;
using DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implement;

public class AccountRepo : IAccountRepo
{
    public async Task<Account> Login(string email, string password)
    {
        return await AccountDAO.Instance.Login(email, password);
    }
}
