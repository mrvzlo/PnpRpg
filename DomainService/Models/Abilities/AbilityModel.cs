using Pnprpg.DomainService.Enums;

namespace Pnprpg.DomainService.Models
{
    public class AbilityModel : Upgradeable, IBaseViewModel
    {
        public AbilityType Type { get; set; }
        public string Color { get; set; }
    }
}