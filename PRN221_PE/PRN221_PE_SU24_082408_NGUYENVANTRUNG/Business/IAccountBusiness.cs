using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public interface IAccountBusiness
    {
        Task<Account?> Login(string email, string password);
       
    }
}
