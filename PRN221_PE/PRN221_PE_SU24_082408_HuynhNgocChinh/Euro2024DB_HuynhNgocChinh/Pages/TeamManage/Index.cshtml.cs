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
    public class IndexModel : PageModel
    {
        private readonly ITeamRepo _teamRepo;

        //search
        [BindProperty(SupportsGet = true)]
        public string searchTerm { get; set; }

        //paging
        public int PageIndex { get; set; } = 1;

        public int TotalPages { get; set; }
        public int PageSize { get; set; } = 2;

        public IList<Team> Team { get; set; } = default!;

        public IndexModel()
        {
            _teamRepo = new TeamRepo();
        }

        

        public async Task OnGetAsync(int pageIndex = 1)
        {
            if (_teamRepo != null)
            {
                var result = await _teamRepo.getList(searchTerm, pageIndex, 8);
                Team = result.Teams;
                PageIndex = result.PageIndex;
                TotalPages = result.TotalPages;
            }
        }
    }
}
