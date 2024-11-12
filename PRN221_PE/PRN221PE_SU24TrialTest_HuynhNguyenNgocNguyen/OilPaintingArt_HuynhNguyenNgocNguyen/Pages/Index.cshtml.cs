using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository;

namespace OilPaintingArt_HuynhNguyenNgocNguyen.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public string email { get; set; }

        [BindProperty]
        public string password { get; set; }

        private readonly ISystemAccountRepository _systemAccountRepository;

        public IndexModel(ISystemAccountRepository systemAccountRepository)
        {
            _systemAccountRepository = systemAccountRepository;
        }

        public async Task<IActionResult> OnPost()
        {
            try
            {
                var systemAccount = await _systemAccountRepository.Login(email, password);
                if (systemAccount != null && (systemAccount.Role == 2 || systemAccount.Role == 3))
                {
                    TempData["Message"] = "Login Success";
                    Console.WriteLine("Login Success");

                    //set session
                    HttpContext.Session.SetString("Email", email);
                    HttpContext.Session.SetInt32("RoleId", systemAccount.Role ?? default(int));

                    return RedirectToPage("/OilPaintingArtPage/Index");
                }
                else
                {
                    TempData["Message"] = "You do not have permission to do this function";
                    return Page();
                }
            }
            catch (Exception ex)
            {
                TempData["Message"] = ex.Message;
                return Page();
            }
        }
    }
}
