using System.Linq;
using Pnprpg.DomainService.Enums;
using Pnprpg.DomainService.Models;

namespace Pnprpg.DomainService.IServices
{
    public interface ISkillService : IViewService<SkillViewModel>, IEditService<SkillEditModel>
    {
        IQueryable<SkillViewModel> SelectSkills(SkillType? type, int? branchId = null);
        HeroSkillGroup GetHeroSkillGroup(HeroModel hero);
        ServiceResponse<HeroModel> UpgradeSkill(HeroModel hero, int skillId);
        HeroModel ResetSkills(HeroModel hero);
        int Save(SkillEditModel viewModel);
    }
}
