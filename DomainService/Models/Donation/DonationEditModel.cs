using System.ComponentModel.DataAnnotations;

namespace Pnprpg.DomainService.Models
{
    public class DonationEditModel : IBaseEditModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required, Range(0.01, 1000)]
        public decimal Total { get; set; }
        [Required, Range(0.00, 1000)]
        public decimal Current { get; set; }
    }
}
