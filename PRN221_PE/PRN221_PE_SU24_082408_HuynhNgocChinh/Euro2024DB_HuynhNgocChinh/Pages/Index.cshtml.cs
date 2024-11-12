using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository;
using Repository.Implement;

namespace Euro2024DB_HuynhNgocChinh.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IAccountRepo _accountRepo;

        [BindProperty]
        public string email { get; set; }

        [BindProperty]
        public string password { get; set; }

        public IndexModel()
        {
            _accountRepo = new AccountRepo();
        }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            try
            {
                var account = await _accountRepo.Login(email, password);
                if (account != null && (account.RoleId == 1 || account.RoleId == 2))
                {
                    TempData["Message"] = "Login Success";
                    Console.WriteLine("Login Success");

                    //set session
                    HttpContext.Session.SetString("Email", email);
                    HttpContext.Session.SetInt32("RoleId", account.RoleId ?? default(int));

                    return RedirectToPage("/TeamManage/Index");
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
