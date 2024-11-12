using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface ICoppaItaliaAccountRepository
    {
        Task<CoppaItaliaAccount> Login(string email, string password);
    }
}
