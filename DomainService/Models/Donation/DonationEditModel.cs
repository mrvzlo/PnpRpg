namespace Pnprpg.DomainService.Models
{
    public class DonationEditModel : IBaseEditModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Total { get; set; }
        public decimal Current { get; set; }
    }
}
