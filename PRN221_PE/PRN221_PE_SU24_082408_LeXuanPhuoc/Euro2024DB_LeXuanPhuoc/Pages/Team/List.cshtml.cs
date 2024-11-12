using BusinessObjects.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories;

namespace Euro2024DB_LeXuanPhuoc.Pages.Team
{
    public class ListModel : PageModel
    {
        public ListModel(ITeamRepository repo)
        {
            _repo = repo;
        }

        public List<BusinessObjects.Entities.Team> Teams { get; set; }

        private readonly ITeamRepository _repo;

        [BindProperty(SupportsGet = true)]
        public string SearchValue { get; set; }


        public async Task<IActionResult> OnGetAsync(int? pageIndex)
        {
            var isLogin = HttpContext.Session.GetInt32("AccountRole") != null;
            if (!isLogin) return RedirectToPage("/Login");

            var teams = await _repo.GetTeamsAsync();
            var pagingItems =
                PagingHelper<BusinessObjects.Entities.Team>.Paging(
                    teams.OrderByDescending(x => x.Id).ToList(),
                    pageIndex ?? 1, 8);

            if (!string.IsNullOrEmpty(SearchValue))
            {
                var searchResults = await _repo.SearchAsync(SearchValue.Trim());

                pagingItems = PagingHelper<BusinessObjects.Entities.Team>.Paging(
                    searchResults.OrderByDescending(x => x.Id).ToList(), 1, 8);
            }

            Teams = pagingItems;
            ViewData["CurrentPage"] = pagingItems.PageIndex;
            ViewData["TotalPage"] = pagingItems.TotalPage;

            return Page();
        }
    }
}


                
