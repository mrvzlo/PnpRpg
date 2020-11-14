using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Pnprpg.DomainService.IServices;
using Pnprpg.DomainService.Models;

namespace Pnprpg.WebCore.Pages.Donation
{
    public class IndexModel : PageModel
    {
        public IQueryable<DonationViewModel> Donations { get; set; }

        private readonly IDonationService _donationService;

        public IndexModel(IDonationService donationService)
        {
            _donationService = donationService;
        }

        public void OnGet()
        {
            Donations = _donationService.GetAll();
        }
    }
}
