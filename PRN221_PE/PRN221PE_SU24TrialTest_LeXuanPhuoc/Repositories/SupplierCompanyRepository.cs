using BusinessObjects.Entities;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class SupplierCompanyRepository : ISupplierCompanyRepository
    {
        public async Task<List<SupplierCompany>> GetSupplierCompaniesAsync()
            => await SupplierCompanyDAO.Instance.GetSupplierCompaniesAsync();
    }
}
