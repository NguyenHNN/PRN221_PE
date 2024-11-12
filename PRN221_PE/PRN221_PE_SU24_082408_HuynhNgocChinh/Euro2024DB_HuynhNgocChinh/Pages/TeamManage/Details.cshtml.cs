using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BOs;
using DAOs;

namespace Euro2024DB_HuynhNgocChinh.Pages.TeamManage
{
    public class DetailsModel : PageModel
    {
        private readonly DAOs.Euro2024DbContext _context;

        public DetailsModel(DAOs.Euro2024DbContext context)
        {
            _context = context;
        }

      public Team Team { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Teams == null)
            {
                return NotFound();
            }

            var team = await _context.Teams.FirstOrDefaultAsync(m => m.Id == id);
            if (team == null)
            {
                return NotFound();
            }
            else 
            {
                Team = team;
            }
            return Page();
        }
    }
}
