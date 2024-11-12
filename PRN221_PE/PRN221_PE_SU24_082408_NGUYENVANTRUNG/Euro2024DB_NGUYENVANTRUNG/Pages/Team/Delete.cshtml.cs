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
    public class DeleteModel : PageModel
    {
          private readonly ITeamBusiness teamBusiness;

        public DeleteModel()
        {
            teamBusiness ??= new TeamBusinessImp();
        }

        [BindProperty]
        public Data.Models.Team Team { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("Email"))
             || string.IsNullOrEmpty((HttpContext.Session.GetString("Role"))))
            {
                TempData["Message"] = "You do not have permission to do this function!";
                return RedirectToPage("/Login");
            }

            if (HttpContext.Session.GetString("Role") != "1")
            {
                TempData["Message"] = "You do not have permission to do this function!";
                return RedirectToPage("/Login");
            }

            var oilpaintingart = await teamBusiness.Getbyid(id);

            if (oilpaintingart == null)
            {
                return NotFound();
            }
            else
            {
                Team = oilpaintingart;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var oilpaintingart = await teamBusiness.Getbyid(id);
            if (oilpaintingart != null)
            {
               var result = await teamBusiness.Remove(oilpaintingart);
                if(result < 1)
                {
                    Team = oilpaintingart;
                    ViewData["message"] = "Delete OilPaintingArt fail";
                    return Page();
                }
            }

            return RedirectToPage("./Index");
        }
    }
}
