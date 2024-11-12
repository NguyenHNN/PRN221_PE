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

namespace Euro2024DB_HuynhNguyenNgocNguyen.Pages.TeamPage
{
    public class DetailsModel : PageModel
    {
        private readonly ITeamRepository _teamRepository;

        public DetailsModel(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        public Team Team { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            Team = await _teamRepository.GetTeamById(id ?? default(int));
            return Page();
        }
    }
}
