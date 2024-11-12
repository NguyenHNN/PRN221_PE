using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObjects;
using DataAccessObjects;
using Repository;

namespace OilPaintingArt_HuynhNguyenNgocNguyen.Pages.OilPaintingArtPage
{
    public class CreateModel : PageModel
    {
        private readonly IOilPaintingArtRepository _oilPaintingArtRepository;
        private readonly ISupplierCompanyRepository _supplierCompanyRepository;


        public CreateModel(IOilPaintingArtRepository oilPaintingArtRepository, ISupplierCompanyRepository supplierCompanyRepository)
        {
            _oilPaintingArtRepository = oilPaintingArtRepository;
            _supplierCompanyRepository = supplierCompanyRepository;
        }

        public async Task <IActionResult> OnGet()
        {
            var listItem = await _supplierCompanyRepository.GetList();
            ViewData["SupplierId"] = new SelectList(listItem, "SupplierId", "CompanyName");
            return Page(); ;
        }

        [BindProperty]
        public OilPaintingArt OilPaintingArt { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                await _oilPaintingArtRepository.AddPainting(OilPaintingArt);
                TempData["Message"] = "Create Succesfull";
                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                TempData["Message"] = ex.Message;
                return await OnGet();
            }
        }
    }
}
