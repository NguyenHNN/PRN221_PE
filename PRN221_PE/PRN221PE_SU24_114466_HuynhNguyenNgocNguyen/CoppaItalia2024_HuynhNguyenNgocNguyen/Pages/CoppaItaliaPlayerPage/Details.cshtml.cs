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

namespace CoppaItalia2024_HuynhNguyenNgocNguyen.Pages.CoppaItaliaPlayerPage
{
    public class DetailsModel : PageModel
    {
        private readonly ICoppaItaliaPlayerRepository _coppaItaliaPlayerRepository;

        public DetailsModel(ICoppaItaliaPlayerRepository coppaItaliaPlayerRepository)
        {
            _coppaItaliaPlayerRepository = coppaItaliaPlayerRepository;
        }

        public CoppaItaliaPlayer CoppaItaliaPlayer { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            CoppaItaliaPlayer = await _coppaItaliaPlayerRepository.GetCoppaItaliaPlayerById(id ?? default(string));
            return Page();
        }
    }
}
