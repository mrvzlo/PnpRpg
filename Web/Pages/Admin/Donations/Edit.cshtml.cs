using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Pnprpg.DomainService.IServices;
using Pnprpg.DomainService.Models;

namespace Pnprpg.WebCore.Pages.Admin.Donations
{
    public class EditModel : AdminPage
    {
        [BindProperty]
        public List<DonationEditModel> Donations { get; set; }
        public StatusResult Status { get; set; }

        private readonly IDonationService _donationService;

        public EditModel(IDonationService donationService)
        {
            _donationService = donationService;
        }

        public void OnGet()
        {
            Donations = _donationService.GetEditModels().ToList();
        }

        public void OnPost()
        {
            if (ModelState.IsValid)
                _donationService.SaveAll(Donations);
            OnGet();
        }
    }
}