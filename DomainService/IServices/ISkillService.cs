using System.Linq;
using Pnprpg.DomainService.Enums;
using Pnprpg.DomainService.Models;

namespace Pnprpg.DomainService.IServices
{
    public interface ISkillService : IViewService<SkillViewModel>, IEditService<SkillEditModel>
    {
        IQueryable<SkillViewModel> SelectSkills(int? branchId = null, SkillType? type = null);
        HeroSkillGroup GetHeroSkillGroup(HeroModel hero);
        ServiceResponse<HeroModel> UpgradeSkill(HeroModel hero, int skillId);
        HeroModel ResetSkills(HeroModel hero);
        void Save(SkillEditModel viewModel);
    }
}
