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
    public class OilPaintingArtDAO
    {
        private static OilPaintingArtDAO instance = null!;
        private static object objectLock = new object();

        public static OilPaintingArtDAO Instance
        {
            get
            {
                lock (objectLock)
                {
                    if (instance == null)
                    {
                        instance = new OilPaintingArtDAO();
                    }
                    return instance;
                }
            }
        }

        public async Task<List<OilPaintingArt>> GetOilPaintingArts()
        {
            using(var context = new OilPaintingArt2024DbContext())
            {
                return await context.OilPaintingArts.Include(x => x.Supplier).ToListAsync();
            }
        }
        public async Task<OilPaintingArt> GetByIdAsync(int OilPaitingArtId)
        {
            using (var context = new OilPaintingArt2024DbContext())
            {
                return await context.OilPaintingArts.FirstOrDefaultAsync(x => x.OilPaintingArtId == OilPaitingArtId) ?? null!;
            }
        }
        public async Task<bool> CreateAsync(OilPaintingArt oilPaintingArt)
        {
            using(var context = new OilPaintingArt2024DbContext())
            {
                await context.OilPaintingArts.AddAsync(oilPaintingArt);
                return await context.SaveChangesAsync() > 0;
            }
        }
        public async Task UpdateAsync(OilPaintingArt oilPaintingArt)
        {
            using (var context = new OilPaintingArt2024DbContext())
            {
                var existPainting = await context.OilPaintingArts.FirstOrDefaultAsync(x => x.OilPaintingArtId == oilPaintingArt.OilPaintingArtId);

                if (existPainting != null)
                {
                    // Update fields
                    existPainting.ArtTitle = oilPaintingArt.ArtTitle;
                    existPainting.OilPaintingArtLocation = oilPaintingArt.OilPaintingArtLocation;
                    existPainting.OilPaintingArtStyle = oilPaintingArt.OilPaintingArtStyle;
                    existPainting.Artist = oilPaintingArt.Artist;
                    existPainting.NotablFeatures = oilPaintingArt.NotablFeatures;
                    existPainting.PriceOfOilPaintingArt = oilPaintingArt.PriceOfOilPaintingArt;
                    existPainting.StoreQuantity = oilPaintingArt.StoreQuantity;
                    existPainting.SupplierId = oilPaintingArt.SupplierId;


                    context.OilPaintingArts.Update(existPainting);
                    await context.SaveChangesAsync();
                }
            }
        }
        public async Task<bool> DeleteAsync(int OilPaintingArtId)
        {
            using(var context = new OilPaintingArt2024DbContext())
            {
                var existPainting = await context.OilPaintingArts.FirstOrDefaultAsync(x => 
                    x.OilPaintingArtId == OilPaintingArtId);

                if(existPainting != null)
                {
                    existPainting.Supplier = null;
                    context.OilPaintingArts.Remove(existPainting);
                    return await context.SaveChangesAsync() > 0;
                }

                return false;
            }
        }
    }
}
