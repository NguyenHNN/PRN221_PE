using BusinessObjects.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories;
using System.Text.RegularExpressions;

namespace Euro2024DB_LeXuanPhuoc.Pages.Team
{
    public class CreateModel : PageModel
    {
        private readonly ITeamRepository _repo;
        private readonly IGroupTeamRepository _groupRepo;

        // Point enum
        public int[] Points = new int[3] {0, 1, 3};

        public CreateModel(ITeamRepository repo, 
            IGroupTeamRepository groupRepo)
        {
            _repo = repo;
            _groupRepo = groupRepo;
        }


        [BindProperty]
        public List<GroupTeam> GroupTeams { get; set; }

        [BindProperty]
        public BusinessObjects.Entities.Team TeamToAdd { get; set; }


        public async Task OnGetAsync()
        {
            GroupTeams = await _groupRepo.GetGroupTeamsAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                GroupTeams = await _groupRepo.GetGroupTeamsAsync();
                return Page();
            }

            if (!Points.Contains(TeamToAdd.Point))
            {
                ModelState.AddModelError("TeamToAdd.Point", "Value for point is enum = {0,1,3}");
                GroupTeams = await _groupRepo.GetGroupTeamsAsync();
                return Page();
            }

            TeamToAdd.Position = (TeamToAdd.Point == 0) ? 4 : TeamToAdd.Point;
            var ToAddResult = await _repo.CreateAsync(TeamToAdd);

            if (ToAddResult) return RedirectToPage("/Team/List");

            return Page();
        }
    }           
}
