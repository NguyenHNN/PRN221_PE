using BusinessObjects.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories;

namespace OilPaintingArt_LeXuanPhuoc.Pages.OilPaintingArt
{
    public class CreateModel : PageModel
    {
        private readonly IOilPaintingArtRepository _oilPaintingArtRepo;
        private readonly ISupplierCompanyRepository _supplierCompanyRepository;

        [BindProperty]
        public BusinessObjects.Entities.OilPaintingArt OilPaintingArtAdd { get; set; }

        [BindProperty]
        public List<SupplierCompany> Suppliers { get; set; }

        public CreateModel(IOilPaintingArtRepository oilPaintingArtRepo, 
            ISupplierCompanyRepository supplierCompanyRepository)
        {
            _oilPaintingArtRepo = oilPaintingArtRepo;
            _supplierCompanyRepository = supplierCompanyRepository;
        }

        public async Task OnGetAsync() 
        {
            Suppliers = await _supplierCompanyRepository.GetSupplierCompaniesAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Suppliers = await _supplierCompanyRepository.GetSupplierCompaniesAsync();
                return Page();
            }

            var paintingArts = await _oilPaintingArtRepo.GetOilPaintingArts();

            OilPaintingArtAdd.OilPaintingArtId = paintingArts.Last().OilPaintingArtId + 1;

            await _oilPaintingArtRepo.CreateAsync(OilPaintingArtAdd);

            return RedirectToPage("/OilPaintingArt/List");
        }
    }
}
