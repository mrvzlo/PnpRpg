using Pnprpg.DomainService.Helpers;

namespace Pnprpg.DomainService.Models
{
    public class HeroSkillGroup : UpgradeableGroup<SkillViewModel>
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

        protected override bool FitsLimit(SkillViewModel target, int modifier) =>
            (target.CalcUpgradePoints(modifier) + TotalSpentPoints()).Fits(Limit);

    }
}
