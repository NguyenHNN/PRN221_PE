using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories;
using System.ComponentModel.DataAnnotations;

namespace Euro2024DB_LeXuanPhuoc.Pages
{
    public class LoginModel : PageModel
    {
        private readonly IAccountRepository _repo;

        public LoginModel(IAccountRepository repo)
        {
            _repo = repo;
        }


        [BindProperty]
        [EmailAddress]
        [Required(ErrorMessage = "Account Email is required")]
        [Display(Name = "Email")]
        public string AccountEmail { get; set; }

        [BindProperty]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Account Password is required")]
        [Display(Name = "Password")]
        public string AccountPassword { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Check exist account
            var existingAccount = await _repo.GetByEmailAsync(AccountEmail);

            if (existingAccount != null
                && existingAccount.Password.Equals(AccountPassword))
            {
                if (existingAccount.RoleId == 3)
                {
                    HttpContext.Session.SetInt32("AccountRole", 3);
                }

                if (existingAccount.RoleId == 2)
                {
                    HttpContext.Session.SetInt32("AccountRole", 2);
                }

                if (existingAccount.RoleId == 1)
                {
                    HttpContext.Session.SetInt32("AccountRole", 1);
                }

                return RedirectToPage("/Team/List");
            }
            else
            {
                ViewData["ErrorMessage"] = "You do not have permission to do this function!";
            }

            return Page();
        }


    }
}
