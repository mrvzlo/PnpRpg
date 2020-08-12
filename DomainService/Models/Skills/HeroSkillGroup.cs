using Pnprpg.DomainService.Helpers;
using Pnprpg.DomainService.Models.Common;

namespace Pnprpg.DomainService.Models.Skills
{
    public class HeroSkillGroup : UpgradeableGroup<SkillModel>
    {
        public int SelectedGroup;
        public bool Editable;

        public HeroSkillGroup() { }

        public HeroSkillGroup(HeroModel hero = null)
        {
            Editable = hero != null;
            if (hero != null)
                Limit = Constants.SkillPointsPerLvl * hero.Level + Constants.BaseSkillPoints;
        }

        protected override bool FitsLimit(SkillModel target, int modifier) =>
            (modifier * (target.Difficulty + 1) + TotalSpentPoints()).Fits(Limit);

    }
}
