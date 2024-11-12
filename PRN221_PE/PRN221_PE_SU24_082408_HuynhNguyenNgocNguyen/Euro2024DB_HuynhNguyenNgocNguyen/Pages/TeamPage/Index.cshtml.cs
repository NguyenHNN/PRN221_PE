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
    public class IndexModel : PageModel
    {
        //search
        [BindProperty(SupportsGet = true)]
        public string searchTerm { get; set; }

        //paging
        public int PageIndex { get; set; } = 1;

        public int TotalPages { get; set; }
        public int PageSize { get; set; } = 2;


        private readonly ITeamRepository _teamRepository;

        public IndexModel(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        public IList<Team> Team { get;set; } = default!;

        public async Task OnGetAsync(int pageIndex = 1)
        {
            var result = await _teamRepository.GetList(searchTerm, pageIndex, 8);

            Team = result.Teams;
            PageIndex = result.PageIndex;
            TotalPages = result.TotalPages;
        }
    }
}
