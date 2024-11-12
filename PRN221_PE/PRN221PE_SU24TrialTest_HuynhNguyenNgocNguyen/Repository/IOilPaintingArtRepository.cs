using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DataAccessObjects.OilPaintingArtDAO;

namespace Repository
{
    public interface IOilPaintingArtRepository
    {
        Task<List<OilPaintingArt>> GetList();
        Task<PaintingResponse> GetList(string searchTerm, int pageIndex, int pageSize);
        Task<OilPaintingArt> GetOilPaintingArtById(int id);
        Task AddPainting(OilPaintingArt oilPaintingArt);
        Task UpdatePainting(OilPaintingArt oilPaintingArt);
        Task DeletePainting(int id);
    }
}
