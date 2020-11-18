using System;

namespace Pnprpg.DomainService.Models
{
    public class DonationViewModel : IBaseViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Total { get; set; }
        public decimal Current { get; set; }

        public int Percent() => Total == 0 ? 0 : (int) Math.Round(100 * Current / Total);
    }
}
