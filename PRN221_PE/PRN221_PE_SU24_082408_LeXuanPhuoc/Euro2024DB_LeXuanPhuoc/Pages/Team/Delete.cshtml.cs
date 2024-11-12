using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories;

namespace Euro2024DB_LeXuanPhuoc.Pages.Team
{
    public class DeleteModel : PageModel
    {
        private readonly ITeamRepository _repo;

        public DeleteModel(ITeamRepository repo)
        {
            _repo = repo;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var toDeleteResult = await _repo.DeleteAsync(id);
            if (toDeleteResult) return RedirectToPage("/Team/List");

            return Page();
        }
    }
}
