using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BOs;
using DAOs;
using Repository;
using Repository.Implement;

namespace Euro2024DB_HuynhNgocChinh.Pages.TeamManage
{
    public class DeleteModel : PageModel
    {
        private readonly ITeamRepo _teamRepo;

        public DeleteModel()
        {
            _teamRepo = new TeamRepo();
        }

        [BindProperty]
      public Team Team { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            Team = await _teamRepo.getTeamById(id ?? default(int));
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            await _teamRepo.RemoveTeam(id ?? default(int));
            return RedirectToPage("./Index");
        }
    }
}
