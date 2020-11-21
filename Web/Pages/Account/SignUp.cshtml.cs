using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pnprpg.DomainService.IServices;
using Pnprpg.DomainService.Models;

namespace Pnprpg.WebCore.Pages.Account
{
    public class SignUpModel : AccountPage
    {
        [BindProperty]
        public RegistrationModel Registration { get; set; }
        
        public SignUpModel(IAccountService accountService) : base(accountService) { }

        public void OnGet(string returnUrl)
        {
            Registration = new RegistrationModel { ReturnUrl = returnUrl };
        }

        public async Task<ActionResult> OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            var response = AccountService.Register(Registration);
            if (response.Successful())
            {
                await CreateTicket(response.Object);
                return Redirect(GetRedirectUrl(Registration.ReturnUrl));
            }

            AddModelStateErrors(response);
            return Page();
        }
    }
}
