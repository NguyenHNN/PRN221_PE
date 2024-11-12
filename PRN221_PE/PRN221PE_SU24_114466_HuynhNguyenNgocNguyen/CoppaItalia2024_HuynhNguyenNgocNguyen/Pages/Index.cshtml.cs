using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository;

namespace CoppaItalia2024_HuynhNguyenNgocNguyen.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public string email { get; set; }

        [BindProperty]
        public string password { get; set; }

        private readonly ICoppaItaliaAccountRepository _coppaItaliaAccountRepository;

        public IndexModel(ICoppaItaliaAccountRepository coppaItaliaAccountRepository)
        {
            _coppaItaliaAccountRepository = coppaItaliaAccountRepository;
        }
        public async Task<IActionResult> OnPost()
        {
            try
            {
                var account = await _coppaItaliaAccountRepository.Login(email, password);
                if (account != null && (account.AccRole == 1 || account.AccRole == 2))
                {
                    TempData["Message"] = "Login Success";
                    Console.WriteLine("Login Success");

                    //set session
                    HttpContext.Session.SetString("Email", email);
                    HttpContext.Session.SetInt32("RoleId", account.AccRole ?? default(int));

                    return RedirectToPage("/CoppaItaliaPlayerPage/Index");
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
