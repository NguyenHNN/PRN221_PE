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
    public class DeleteModel : PageModel
    {
        private readonly ICoppaItaliaPlayerRepository _coppaItaliaPlayerRepository;

        public DeleteModel(ICoppaItaliaPlayerRepository coppaItaliaPlayerRepository)
        {
            _coppaItaliaPlayerRepository = coppaItaliaPlayerRepository;
        }

        [BindProperty]
        public CoppaItaliaPlayer CoppaItaliaPlayer { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coppaitaliaplayer = await _coppaItaliaPlayerRepository.GetCoppaItaliaPlayerById(id ?? default(string));

            if (coppaitaliaplayer == null)
            {
                return NotFound();
            }
            else
            {
                CoppaItaliaPlayer = coppaitaliaplayer;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }
                await _coppaItaliaPlayerRepository.DeletePlayer(id ?? default(string));
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
