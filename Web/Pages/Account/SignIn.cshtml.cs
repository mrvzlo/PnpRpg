using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Pnprpg.DomainService.IServices;
using Pnprpg.DomainService.Models;

namespace Pnprpg.WebCore.Pages.Account
{
    public class SignInModel : AccountPage
    {
        [BindProperty]
        public LoginModel Login { get; set; }
        
        public SignInModel(IAccountService accountService) : base(accountService) { }

        public void OnGet(string returnUrl)
        {
            Login = new LoginModel{ReturnUrl = returnUrl};
        }

        public ActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            var response = AccountService.Login(Login);
            if (response.Successful())
            {
                CreateTicket(response.Object);
                return Redirect(GetRedirectUrl(Login.ReturnUrl));
            }

            AddModelStateErrors(response);
            return Page();
        }
    }
}
