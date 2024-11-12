using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository;

namespace Euro2024DB_HuynhNguyenNgocNguyen.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public string email { get; set; }

        [BindProperty]
        public string password { get; set; }
        private readonly IAccountRepository _accountRepository;

        public IndexModel(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<IActionResult> OnPost()
        {
            try
            {
                var account = await _accountRepository.Login(email, password);
                if (account != null && (account.RoleId == 1 || account.RoleId == 2))
                {
                    TempData["Message"] = "Login Success";
                    Console.WriteLine("Login Success");

                    //set session
                    HttpContext.Session.SetString("Email", email);
                    HttpContext.Session.SetInt32("RoleId", account.RoleId ?? default(int));

                    return RedirectToPage("/TeamPage/Index");
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

        public void OnGet()
        {

        }
    }
}
