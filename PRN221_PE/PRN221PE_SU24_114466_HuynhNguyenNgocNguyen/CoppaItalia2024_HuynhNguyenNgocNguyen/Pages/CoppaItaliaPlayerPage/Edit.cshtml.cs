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

namespace CoppaItalia2024_HuynhNguyenNgocNguyen.Pages.CoppaItaliaPlayerPage
{
    public class EditModel : PageModel
    {
        private readonly ICoppaItaliaPlayerRepository _coppaItaliaPlayerRepository;
        private readonly ICoppaItaliaClubRepository _coppaItaliaClubRepository;


        public EditModel(ICoppaItaliaPlayerRepository coppaItaliaPlayerRepository, ICoppaItaliaClubRepository coppaItaliaClubRepository)
        {
            _coppaItaliaPlayerRepository = coppaItaliaPlayerRepository;
            _coppaItaliaClubRepository = coppaItaliaClubRepository;
        }

        [BindProperty]
        public CoppaItaliaPlayer CoppaItaliaPlayer { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coppaitaliaplayer =  await _coppaItaliaPlayerRepository.GetCoppaItaliaPlayerById(id ?? default(string));
            if (coppaitaliaplayer == null)
            {
                return NotFound();
            }
            CoppaItaliaPlayer = coppaitaliaplayer;
            var list = await _coppaItaliaClubRepository.GetList();
            ViewData["CoppaItaliaClubID"] = new SelectList(list, "CoppaItaliaClubID", "ClubName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                await _coppaItaliaPlayerRepository.UpdatePlayer(CoppaItaliaPlayer);
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
