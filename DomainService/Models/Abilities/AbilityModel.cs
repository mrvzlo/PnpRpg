namespace Pnprpg.DomainService.Models
{
    public class AbilityModel : Upgradeable, IBaseViewModel
    {
        public string Symbol { get; set; }
        public string Color { get; set; }
    }
}