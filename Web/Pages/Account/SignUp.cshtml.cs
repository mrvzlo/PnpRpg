using System;
using Microsoft.AspNetCore.Mvc;
using Pnprpg.DomainService.IServices;
using Pnprpg.DomainService.Models;

namespace Pnprpg.WebCore.Pages.Account
{
    public class SignUpModel : AccountPage
    {
        public RegistrationModel Registration { get; set; }
        
        public SignUpModel(IAccountService accountService) : base(accountService) { }

        public void OnGet(string returnUrl)
        {
            Registration = new RegistrationModel { ReturnUrl = returnUrl };
        }

        public ActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            var response = AccountService.Register(Registration);
            if (response.Successful())
            {
                CreateTicket(response.Object);
                return Redirect(GetRedirectUrl(Registration.ReturnUrl));
            }

            AddModelStateErrors(response);
            return Page();
        }
    }
}
