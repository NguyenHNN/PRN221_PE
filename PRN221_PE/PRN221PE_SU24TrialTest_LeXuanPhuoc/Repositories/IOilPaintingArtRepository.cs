using BusinessObjects.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IOilPaintingArtRepository
    {
        Task<List<OilPaintingArt>> GetOilPaintingArts();
        Task<OilPaintingArt> GetByIdAsync(int OilPaintingArtId);
        Task<bool> CreateAsync(OilPaintingArt oilPaintingArt);
        Task UpdateAsync(OilPaintingArt oilPaintingArt);
        Task<bool> DeleteAsync(int OilPaintingArtId);
    }
}
