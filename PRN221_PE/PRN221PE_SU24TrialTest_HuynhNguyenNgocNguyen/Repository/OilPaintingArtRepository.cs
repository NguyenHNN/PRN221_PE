using BusinessObjects;
using DataAccessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class OilPaintingArtRepository:IOilPaintingArtRepository
    {

        public Task<List<OilPaintingArt>> GetList()
        {
            return OilPaintingArtDAO.Instance.GetList();
        }

        public Task<OilPaintingArtDAO.PaintingResponse> GetList(string searchTerm, int pageIndex, int pageSize)
        {
            return OilPaintingArtDAO.Instance.GetList(searchTerm, pageIndex, pageSize);
        }

        public Task<OilPaintingArt> GetOilPaintingArtById(int id)
        {
            return OilPaintingArtDAO.Instance.GetOilPaintingArtById(id);
        }

        public Task AddPainting(OilPaintingArt oilPaintingArt)
        {
            return OilPaintingArtDAO.Instance.AddPainting(oilPaintingArt);
        }
        public Task UpdatePainting(OilPaintingArt oilPaintingArt)
        {
            return OilPaintingArtDAO.Instance.UpdatePainting(oilPaintingArt);
        }
        public Task DeletePainting(int id)
        {
            return OilPaintingArtDAO.Instance.DeleteArt(id);
        }
    }
}
