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

namespace CoppaItalia2024_HuynhNguyenNgocNguyen.Pages.CoppaItaliaPlayerPage
{
    public class CreateModel : PageModel
    {
        private readonly ICoppaItaliaPlayerRepository _coppaItaliaPlayerRepository;
        private readonly ICoppaItaliaClubRepository _coppaItaliaClubRepository;

        public CreateModel(ICoppaItaliaPlayerRepository coppaItaliaPlayerRepository,ICoppaItaliaClubRepository coppaItaliaClubRepository)
        {
            _coppaItaliaPlayerRepository = coppaItaliaPlayerRepository;
            _coppaItaliaClubRepository = coppaItaliaClubRepository;
        }

        public async Task<IActionResult> OnGet()
        {
            var listItem = await _coppaItaliaClubRepository.GetList();
            ViewData["CoppaItaliaClubID"] = new SelectList(listItem, "CoppaItaliaClubID", "ClubName");
            return Page(); ;
        }

        [BindProperty]
        public CoppaItaliaPlayer CoppaItaliaPlayer { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                await _coppaItaliaPlayerRepository.AddPlayer(CoppaItaliaPlayer);
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
