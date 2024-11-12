using BusinessObjects.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OilPaintingArt_LeXuanPhuoc.Pages
{
    public class LoginModel : PageModel
    {

        //admin@OilPaintingArtStore.com.au - @33

        private readonly ISystemAccountRepository _accountRepo;
        //[BindProperty] public SystemAccount SystemAccount { get; set; }

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


        public LoginModel(ISystemAccountRepository accountRepo)
        {
            _accountRepo = accountRepo;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var systemAccount = await _accountRepo.GetAccountByEmailAsync(AccountEmail);

            if (systemAccount != null
                && systemAccount.AccountPassword.Equals(AccountPassword))
            {

                if (systemAccount.Role == 2)
                {
                    HttpContext.Session.SetInt32("AccountRole", 2); // Staff
                }
                else if (systemAccount.Role == 3)
                {
                    HttpContext.Session.SetInt32("AccountRole", 3); // Manager
                }

                return RedirectToPage("/OilPaintingArt/List");
            }
            else
            {
                ViewData["ErrorMessage"] = "You do not have permission to do this function!";
            }

            return Page();
        }
    }
}
