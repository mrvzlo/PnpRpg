using Pnprpg.DomainService.Enums;
using Pnprpg.DomainService.Helpers;
using Pnprpg.DomainService.Models.Common;

namespace Pnprpg.DomainService.Models.Abilities
{
    public class HeroAbilityGroup : UpgradeableGroup<AbilityModel>
    {
        public HeroAbilityGroup()
        {
            Limit = Constants.BaseHeroAbilityLevelSum;
        }

        public void Setup(ChaosLevel chaos)
        {
            foreach (var item in List)
            {
                item.Min = chaos == ChaosLevel.Normal
                    ? Constants.ManualMinAbilityLevel
                    : Constants.AbsoluteMinAbilityLevel;
                item.Max = chaos == ChaosLevel.Normal
                    ? Constants.ManualMaxAbilityLevel
                    : Constants.AbsoluteMaxAbilityLevel;
                item.Level = item.Min;
            }
        }
    }
}
