using Pnprpg.DomainService.Enums;

namespace Pnprpg.WebCore.Helpers
{
    public static class StageHelper
    {
        public static string GetPage(HeroGenStage stage)
        {
            switch (stage)
            {
                case HeroGenStage.Race:
                    return SitePages.HeroGenRace;
                case HeroGenStage.Branch:
                    return SitePages.HeroGenBranch;
                case HeroGenStage.Traits:
                    return SitePages.HeroGenTraits;
                case HeroGenStage.Abilities:
                    return SitePages.HeroGenAbilities;
                case HeroGenStage.Result:
                    return SitePages.HeroGenResult;
                default:
                    return null;
            }
        }
    }
}
