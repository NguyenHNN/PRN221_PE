using BOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository;

public interface IAccountRepo
{
    Task<Account> Login(string email, string password);
}
