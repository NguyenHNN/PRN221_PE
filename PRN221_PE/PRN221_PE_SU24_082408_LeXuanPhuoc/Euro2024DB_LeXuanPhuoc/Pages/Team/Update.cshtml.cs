using BusinessObjects.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories;

namespace Euro2024DB_LeXuanPhuoc.Pages.Team
{
    public class UpdateModel : PageModel
    {
        private readonly ITeamRepository _repo;
        private readonly IGroupTeamRepository _groupRepo;


        public UpdateModel(ITeamRepository repo,
            IGroupTeamRepository groupRepo)
        {
            _repo = repo;
            _groupRepo = groupRepo;
        }

        [BindProperty]
        public List<GroupTeam> GroupTeams { get; set; }

        [BindProperty]
        public BusinessObjects.Entities.Team TeamToUpdate { get; set; }

        public async Task OnGetAsync(int id)
        {
            TeamToUpdate = await _repo.GetByIdAsync(id);
            GroupTeams = await _groupRepo.GetGroupTeamsAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                GroupTeams = await _groupRepo.GetGroupTeamsAsync();
                return Page();
            }

            TeamToUpdate.Position = (TeamToUpdate.Point == 0) ? 4 : TeamToUpdate.Point;
            await _repo.UpdateAsync(TeamToUpdate);
            return RedirectToPage("/Team/List");
        }
    }
}
