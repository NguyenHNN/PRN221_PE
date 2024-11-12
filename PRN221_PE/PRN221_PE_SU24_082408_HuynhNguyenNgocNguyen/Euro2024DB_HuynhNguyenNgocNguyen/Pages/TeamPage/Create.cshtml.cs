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

namespace Euro2024DB_HuynhNguyenNgocNguyen.Pages.TeamPage
{
    public class CreateModel : PageModel
    {
        private readonly ITeamRepository _teamRepository;
        private readonly IGroupTeamRepository _groupTeamRepository;

        public CreateModel(ITeamRepository teamRepository, IGroupTeamRepository groupTeamRepository)
        {
            _teamRepository = teamRepository;
            _groupTeamRepository = groupTeamRepository;
        }

        public async Task<IActionResult> OnGet()
        {
            var listItem = await _groupTeamRepository.GetList();
            ViewData["GroupId"] = new SelectList(listItem, "GroupId", "GroupName");
            return Page(); ;
        }

        [BindProperty]
        public Team Team { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                await _teamRepository.AddTeam(Team);
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
