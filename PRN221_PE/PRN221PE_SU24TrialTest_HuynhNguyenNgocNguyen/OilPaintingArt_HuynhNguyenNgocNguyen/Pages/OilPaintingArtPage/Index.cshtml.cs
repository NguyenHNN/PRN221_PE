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
    public class IndexModel : PageModel
    {
        //search
        [BindProperty(SupportsGet = true)]
        public string searchTerm { get; set; }

        //paging
        public int PageIndex { get; set; } = 1;

        public int TotalPages { get; set; }
        public int PageSize { get; set; } = 2;

        private readonly IOilPaintingArtRepository _oilPaintingArtRepository;

        public IndexModel(IOilPaintingArtRepository oilPaintingArtRepository)
        {
            _oilPaintingArtRepository = oilPaintingArtRepository;
        }

        public IList<OilPaintingArt> OilPaintingArt { get;set; } = default!;

        public async Task OnGetAsync(int pageIndex = 1)
        {
            var result = await _oilPaintingArtRepository.GetList(searchTerm, pageIndex, 2);

            OilPaintingArt = result.OilPaintingArts;
            PageIndex = result.PageIndex;
            TotalPages = result.TotalPages;
        }
    }
}
