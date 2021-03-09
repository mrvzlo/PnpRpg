using Pnprpg.DomainService.Enums;

namespace Pnprpg.WebCore.Helpers
{
    public static class StageHelper
    {
        public static string GetPage(HeroGenStage stage)
        {
            return stage switch
            {
                HeroGenStage.Race => SitePages.MajorHeroGenRace,
                HeroGenStage.Branch => SitePages.MajorHeroGenBranch,
                HeroGenStage.Traits => SitePages.MajorHeroGenTraits,
                HeroGenStage.Abilities => SitePages.MajorHeroGenAbilities,
                HeroGenStage.Result => SitePages.MajorHeroGenResult,
                _ => null
            };
        }
    }
}
