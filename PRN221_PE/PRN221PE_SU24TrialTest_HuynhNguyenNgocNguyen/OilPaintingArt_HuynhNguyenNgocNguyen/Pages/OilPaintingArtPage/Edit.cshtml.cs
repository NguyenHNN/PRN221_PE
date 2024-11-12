using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BusinessObjects;
using DataAccessObjects;
using Repository;

namespace OilPaintingArt_HuynhNguyenNgocNguyen.Pages.OilPaintingArtPage
{
    public class EditModel : PageModel
    {
       private readonly IOilPaintingArtRepository _oilPaintingArtRepository;
        private readonly ISupplierCompanyRepository _supplierCompanyRepository;

        public EditModel(IOilPaintingArtRepository oilPaintingArtRepository, ISupplierCompanyRepository supplierCompanyRepository)
        {
            _oilPaintingArtRepository = oilPaintingArtRepository;
            _supplierCompanyRepository = supplierCompanyRepository;
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
            OilPaintingArt = oilpaintingart;
            var list = await _supplierCompanyRepository.GetList();
            ViewData["SupplierId"] = new SelectList(list, "SupplierId", "CompanyName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                await _oilPaintingArtRepository.UpdatePainting(OilPaintingArt);
                TempData["Message"] = "Update Succesfull";

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
