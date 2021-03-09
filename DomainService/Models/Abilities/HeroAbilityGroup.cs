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

        public void Setup(MajorSettings major)
        {
            foreach (var item in List)
            {
                item.Min = major.MinAbility;
                item.Max = major.MaxAbility;
                item.Level = item.Min;
            }
        }

        public bool Update(AbilityType type, int modifier = 1, bool manual = true)
        {
            var target = List.SingleOrDefault(x => x.Type == type);
            return target != null && Update(target, modifier, manual, false);
        }
    }
}
