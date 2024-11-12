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
    public class DeleteModel : PageModel
    {
        private readonly IOilPaintingArtRepository _oilPaintingArtRepository;

        public DeleteModel(IOilPaintingArtRepository oilPaintingArtRepository)
        {
            _oilPaintingArtRepository = oilPaintingArtRepository;
        }

        [BindProperty]
        public OilPaintingArt OilPaintingArt { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oilpaintingart = await _oilPaintingArtRepository.GetOilPaintingArtById(id ?? default(int));

            if (oilpaintingart == null)
            {
                return NotFound();
            }
            else
            {
                OilPaintingArt = oilpaintingart;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }
                await _oilPaintingArtRepository.DeletePainting(id ?? default(int));
                TempData["Message"] = "Delete Succesfull";

                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                TempData["Message"] = ex.Message;
                return Page();
            }
        }
    }
}
