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
    public class SupplierCompanyDAO
    {
        private static SupplierCompanyDAO instance;
        private static object objectLock = new object();

        public static SupplierCompanyDAO Instance
        {
            get
            {
                lock (objectLock)
                {
                    if(instance == null)
                    {
                        instance = new SupplierCompanyDAO();
                    }
                    return instance;
                }
            }
        }

        public async Task<List<SupplierCompany>> GetSupplierCompaniesAsync()
        {
            using(var context = new OilPaintingArt2024DbContext())
            {
                return await context.SupplierCompanies.ToListAsync();   
            }
        }
    }
}
