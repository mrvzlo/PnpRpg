using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Pnprpg.DomainService.IServices;
using Pnprpg.DomainService.Models;

namespace Pnprpg.WebCore.Pages.Donation
{
    public class IndexModel : PageModel
    {
        public string BankAccount { get; set; }
        public IQueryable<DonationViewModel> Donations { get; set; }

        private readonly IDonationService _donationService;
        private readonly IConfiguration _configuration;

        public IndexModel(IDonationService donationService, IConfiguration configuration)
        {
            _donationService = donationService;
            _configuration = configuration;
        }

        public void OnGet()
        {
            BankAccount = _configuration["BankAccount"];
            Donations = _donationService.GetAll();
        }
    }
}
