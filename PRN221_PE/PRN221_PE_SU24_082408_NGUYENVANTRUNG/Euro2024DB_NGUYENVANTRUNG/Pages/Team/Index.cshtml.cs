using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Data.Models;
using Business;

namespace Euro2024DB_NGUYENVANTRUNG.Pages.Team
{
    public class IndexModel : PageModel
    {
        private readonly ITeamBusiness _teamBusiness;

        public IndexModel()
        {
            _teamBusiness = new TeamBusinessImp();
        }
        [BindProperty(SupportsGet = true)]
        public string Position { get; set; } = string.Empty;
        [BindProperty(SupportsGet = true)]
        public string Name { get; set; } = string.Empty;

        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 1;

        [BindProperty]
        public int PageTotal { get; set; } = default!;
        [BindProperty]

        public IList<Data.Models.Team> Teams { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("Email"))
                || string.IsNullOrEmpty((HttpContext.Session.GetString("Role"))))
            {
                TempData["Message"] = "You do not have permission to do this function!";
                return RedirectToPage("/Login");
            }

            if (HttpContext.Session.GetString("Role") == "3" || HttpContext.Session.GetString("Role") == "2")
            {
                TempData["Message"] = "You do not have permission to do this function!";
                return RedirectToPage("/Login");
            }

            var result = await _teamBusiness.GetTeam(Position, Name, CurrentPage, 8);
            if (result != null)
            {
                Teams = result.Result;
                PageTotal = result.TotalPage;
            }
            return Page();
        }
    }
}
