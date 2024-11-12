using BusinessObjects.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories;

namespace OilPaintingArt_LeXuanPhuoc.Pages.OilPaintingArt
{
    public class UpdateModel : PageModel
    {
        private readonly IOilPaintingArtRepository _paintingArtRepo;
        private readonly ISupplierCompanyRepository _supplierCompanyRepo;

        [BindProperty]
        public BusinessObjects.Entities.OilPaintingArt OilPaintingArtUpdate { get; set; }

        [BindProperty]
        public List<SupplierCompany> Suppliers { get; set; }

        public UpdateModel(IOilPaintingArtRepository paintingArtRepo,
            ISupplierCompanyRepository supplierCompanyRepo)
        {
            _paintingArtRepo = paintingArtRepo;
            _supplierCompanyRepo = supplierCompanyRepo;
        }

        public async Task OnGetAsync(int OilPaintingArtId)
        {
            OilPaintingArtUpdate = await _paintingArtRepo.GetByIdAsync(OilPaintingArtId);
            Suppliers = await _supplierCompanyRepo.GetSupplierCompaniesAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if(!ModelState.IsValid)
            {
                Suppliers = await _supplierCompanyRepo.GetSupplierCompaniesAsync();
                return Page();
            }

            await _paintingArtRepo.UpdateAsync(OilPaintingArtUpdate);
            OilPaintingArtUpdate = await _paintingArtRepo.GetByIdAsync(OilPaintingArtUpdate.OilPaintingArtId);
            Suppliers = await _supplierCompanyRepo.GetSupplierCompaniesAsync();

            return Page();
        }
    }
}
