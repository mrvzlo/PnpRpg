using System.Linq;
using Pnprpg.DomainService.Enums;
using Pnprpg.DomainService.Models;

namespace Pnprpg.DomainService.IServices
{
    public interface ISkillService
    {
        IQueryable<BranchModel> GetAllBranches();
        SkillEditModel GetForEdit(int? id);
        IQueryable<SkillViewModel> GetAllSkills(int? branchId = null, SkillType? type = null);
        HeroSkillGroup GetHeroSkillGroup(HeroModel hero);
        ServiceResponse<HeroModel> UpgradeSkill(HeroModel hero, int skillId);
        HeroModel ResetSkills(HeroModel hero);
        void Save(SkillEditModel viewModel);
        void Delete(int id);
    }
}
