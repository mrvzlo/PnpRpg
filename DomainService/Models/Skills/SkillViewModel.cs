using Pnprpg.DomainService.Enums;
using Pnprpg.DomainService.Helpers;

namespace Pnprpg.DomainService.Models
{
    public class SkillViewModel : Upgradeable
    {
        public string BranchName { get; set; }
        public int Difficulty { get; set; }
        public SkillType Type { get; set; }

        public AbilityModel Ability { get; set; }

        public SkillViewModel()
        {
            Max = Constants.MaxSkillLevel;
        }
        
        public override bool FitsLimits(int modifier) =>
            base.FitsLimits(CalcUpgradePoints(modifier));

        public override int SpentPoints() => CalcUpgradePoints(0, Level);

        public override string ToString() => Level > 0 ? $"{Name} ({Level})" : Name;

        public int CalcUpgradePoints(int modifier) => CalcUpgradePoints(Level, Level + modifier);

        private int CalcUpgradePoints(int from, int to)
        {
            var spent = 0;
            for (var i = from; i < to; i++)
                spent += 1 + i / 2;
            return spent;
        }
    }
}