using Data;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class AccountBusinessImp : IAccountBusiness
    {
        private readonly IAccountRepository _accountRepository;

        public AccountBusinessImp()
        {
            _accountRepository = new AccountRepository();
        }

        public async Task<Account?> Login(string email, string password)
        {
            return await _accountRepository.Authentication(email, password);

        }
    }
}
