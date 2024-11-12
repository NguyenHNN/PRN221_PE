using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories;

namespace OilPaintingArt_LeXuanPhuoc.Pages.OilPaintingArt
{
    public class DeleteModel : PageModel
    {
        private readonly IOilPaintingArtRepository _oilPaintingArtRepo;

        public DeleteModel(IOilPaintingArtRepository oilPaintingArtRepo)
        {
            _oilPaintingArtRepo = oilPaintingArtRepo;
        }

        public async Task<IActionResult> OnGetAsync(int OilPaintingArtId)
        {
            await _oilPaintingArtRepo.DeleteAsync(OilPaintingArtId);

            return RedirectToPage("/OilPaintingArt/List");
        }
    }
}
