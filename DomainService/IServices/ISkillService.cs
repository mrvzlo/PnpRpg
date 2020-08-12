using System.Linq;
using Pnprpg.DomainService.Models;
using Pnprpg.DomainService.Models.Processing;
using Pnprpg.DomainService.Models.Skills;

namespace Pnprpg.DomainService.IServices
{
    public interface ISkillService
    {
        IQueryable<SkillGroupModel> GetAllGroups();
        IQueryable<SkillModel> GetSkillsByGroup(int? groupId = null);
        HeroSkillGroup GetHeroSkillGroup(HeroModel hero);
        ServiceResponse<HeroModel> UpgradeSkill(HeroModel hero, int skillId);
        HeroModel ResetSkills(HeroModel hero);
    }
}
