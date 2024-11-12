using BusinessObjects.Entities;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class OilPaintingArtRepository : IOilPaintingArtRepository
    {
        public async Task<bool> CreateAsync(OilPaintingArt oilPaintingArt)
            => await OilPaintingArtDAO.Instance.CreateAsync(oilPaintingArt);
        
        public async Task<bool> DeleteAsync(int OilPaintingArtId)
            => await OilPaintingArtDAO.Instance.DeleteAsync(OilPaintingArtId);

        public async Task<OilPaintingArt> GetByIdAsync(int OilPaintingArtId)
            => await OilPaintingArtDAO.Instance.GetByIdAsync(OilPaintingArtId);

        public async Task<List<OilPaintingArt>> GetOilPaintingArts()
            => await OilPaintingArtDAO.Instance.GetOilPaintingArts();
        
        public async Task UpdateAsync(OilPaintingArt oilPaintingArt)
            => await OilPaintingArtDAO.Instance.UpdateAsync(oilPaintingArt);
    }
}
