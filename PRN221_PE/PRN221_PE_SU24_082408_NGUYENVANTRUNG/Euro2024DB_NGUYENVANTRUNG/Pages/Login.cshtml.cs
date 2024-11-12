using Business;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace Euro2024DB_NGUYENVANTRUNG.Pages
{
    public class LoginModel : PageModel
    {
        private readonly IAccountBusiness _accountBusiness;
        public LoginModel()
        {
            _accountBusiness ??= new AccountBusinessImp();
        }
        [BindProperty]
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = default!;

        [BindProperty]
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = default!;
        public void OnGet()
        {
            HttpContext.Session.Clear();
            ViewData["Message"] = TempData["Message"];
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var account = await _accountBusiness.Login(Email, Password);
            if (account != null)
            {
                HttpContext.Session.SetString("Email", account.Email ?? "");
                HttpContext.Session.SetString("Role", account.RoleId.ToString() ?? "");
                return RedirectToPage("/Team/Index");
            }
            else
            {
                ViewData["message"] = "You do not have permission to do this function!";
            }

            return Page();
        }
    }
}
