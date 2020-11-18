using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Pnprpg.DomainService.IServices;
using Pnprpg.DomainService.Models;

namespace Pnprpg.WebCore.Pages.Admin
{
    public class EditModel : AdminPage
    {
        [BindProperty]
        public List<UserEditModel> Users { get; set; }

        private readonly IAccountService _accountService;

        public EditModel(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public void OnGet()
        {
            Users = _accountService.GetEditModels().ToList();
        }

        public void OnPost()
        {
            _accountService.SaveAllUsers(Users);
            OnGet();
        }
    }
}
