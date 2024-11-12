using BusinessObjects;
using DataAccessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class SupplierCompanyRepository: ISupplierCompanyRepository
    {
        public async Task<List<SupplierCompany>> GetList()
        {
            return await OilPaintingArtDAO.Instance.GetSuppilers();
        }

    }
}
