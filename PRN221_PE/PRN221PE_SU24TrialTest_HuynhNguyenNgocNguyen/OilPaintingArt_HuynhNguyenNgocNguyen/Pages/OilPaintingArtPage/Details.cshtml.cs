using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects;
using DataAccessObjects;
using Repository;

namespace OilPaintingArt_HuynhNguyenNgocNguyen.Pages.OilPaintingArtPage
{
    public class DetailsModel : PageModel
    {
       private readonly IOilPaintingArtRepository _oilPaintingArtRepository;

        public DetailsModel(IOilPaintingArtRepository oilPaintingArtRepository)
        {
            _oilPaintingArtRepository = oilPaintingArtRepository;
        }

        public OilPaintingArt OilPaintingArt { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            OilPaintingArt = await _oilPaintingArtRepository.GetOilPaintingArtById(id ?? default(int));
            return Page();
        }
    }
}
