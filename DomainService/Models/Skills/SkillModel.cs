using Pnprpg.DomainService.Helpers;
using Pnprpg.DomainService.Models.Abilities;
using Pnprpg.DomainService.Models.Common;

namespace Pnprpg.DomainService.Models.Skills
{
    public class SkillModel : Upgradeable
    {
        public int Difficulty { get; set; }
        public string GroupName { get; set; }

        public AbilityModel Ability { get; set; }

        public SkillModel()
        {
            Max = Constants.MaxSkillLevel;
        }

        public override bool FitsLimits(int modifier) => 
            base.FitsLimits(modifier * (Difficulty + 1));

        public override int SpentPoints() => Level * (Difficulty + 1);
        
        public override string ToString() => Level > 0 ? $"{Name} ({Level})" : Name;
    }
}