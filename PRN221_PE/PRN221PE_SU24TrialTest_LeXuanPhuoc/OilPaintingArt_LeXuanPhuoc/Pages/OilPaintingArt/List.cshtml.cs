using BusinessObjects.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OilPaintingArt_LeXuanPhuoc.Utils;
using Repositories;

namespace OilPaintingArt_LeXuanPhuoc.Pages.OilPaintingArt
{
    public class ListModel : PageModel
    {
        // List of Oil Painting Art
        public List<BusinessObjects.Entities.OilPaintingArt> OilPaintingArts { get; set; }

        // Repository
        private readonly IOilPaintingArtRepository _oilPaintingArtRepo;

        // Search term 
        [BindProperty(SupportsGet = true)] 
        public string SearchTerm { get; set; }


        public ListModel(IOilPaintingArtRepository oilPaintingArtRepo)
        {
            _oilPaintingArtRepo = oilPaintingArtRepo;
        }


        public async Task<IActionResult> OnGetAsync(int? pageIndex)
        {
            // Check login success
            var isLogin = HttpContext.Session.GetInt32("AccountRole") != null;
            if (!isLogin) return RedirectToPage("/Login");

            // Get list + Pagination
            var oilPaintingArts = await _oilPaintingArtRepo.GetOilPaintingArts();
            var paginationList =
                PaginatedList<BusinessObjects.Entities.OilPaintingArt>.Paginate(
                    oilPaintingArts.OrderByDescending(x => x.OilPaintingArtId).ToList(),
                    pageIndex ?? 1, 2);

            // Search all items wit 2 conditions: OilPaintingArtStyle, Artist
            if (!string.IsNullOrEmpty(SearchTerm))
            {
                var searchValue = SearchTerm.Trim();

                var searchResults = paginationList.Where(
                    x => x.OilPaintingArtStyle != null && x.OilPaintingArtStyle.Contains(searchValue)
                 || x.Artist != null && x.Artist.Contains(searchValue))
                .ToList();

                paginationList = PaginatedList<BusinessObjects.Entities.OilPaintingArt>.Paginate(
                    searchResults.OrderByDescending(x => x.OilPaintingArtId).ToList(), 1, 2);
            }

            OilPaintingArts = paginationList;
            ViewData["PageIndex"] = paginationList.PageIndex;
            ViewData["TotalPage"] = paginationList.TotalPage;

            return Page();
        }
    }
}
