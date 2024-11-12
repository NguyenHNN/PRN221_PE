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

namespace CoppaItalia2024_HuynhNguyenNgocNguyen.Pages.CoppaItaliaPlayerPage
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

        private readonly ICoppaItaliaPlayerRepository _coppaItaliaPlayerRepository;

        public IndexModel(ICoppaItaliaPlayerRepository coppaItaliaPlayerRepository)
        {
            _coppaItaliaPlayerRepository = coppaItaliaPlayerRepository;
        }

        public IList<CoppaItaliaPlayer> CoppaItaliaPlayer { get; set; } = default!;

        public async Task OnGetAsync(int pageIndex = 1)
        {
            var result = await _coppaItaliaPlayerRepository.GetList(searchTerm, pageIndex, 4);

            CoppaItaliaPlayer = result.CoppaItaliaPlayers;
            PageIndex = result.PageIndex;
            TotalPages = result.TotalPages;
        }
    }
}
