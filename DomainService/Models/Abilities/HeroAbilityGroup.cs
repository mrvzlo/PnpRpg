using System.Linq;
using Pnprpg.DomainService.Enums;
using Pnprpg.DomainService.Helpers;

namespace Pnprpg.DomainService.Models
{
    public class HeroAbilityGroup : UpgradeableGroup<AbilityModel>
    {
        public HeroAbilityGroup() { }

        public void SetLimit() => 
            Limit = Constants.BaseAbilityPoints + List.Select(x => x.Min).Sum();

        public void Setup(Company chaos)
        {
            foreach (var item in List)
            {
                item.Min = chaos == Company.Fantasy
                    ? Constants.ManualMinAbilityLevel
                    : Constants.AbsoluteMinAbilityLevel;
                item.Max = chaos == Company.Fantasy
                    ? Constants.ManualMaxAbilityLevel
                    : Constants.AbsoluteMaxAbilityLevel;
                item.Level = item.Min;
            }
        }
    }
}
