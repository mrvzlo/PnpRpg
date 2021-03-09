using System.Linq;
using Pnprpg.DomainService.Enums;
using Pnprpg.DomainService.Models;

namespace Pnprpg.DomainService.IServices
{
    public interface ISkillService : IEditService<SkillEditModel>
    {
        IQueryable<SkillViewModel> SelectSkills(MajorType major, SkillType? type, int? branchId = null);
        HeroSkillGroup GetHeroSkillGroup(HeroModel hero);
        int Save(SkillEditModel viewModel);
        IQueryable<SkillViewModel> GetAll(MajorType major, int? filter = null);
    }
}
