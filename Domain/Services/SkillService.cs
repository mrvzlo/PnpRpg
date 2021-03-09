using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Pnprpg.DomainService.Enums;
using Pnprpg.DomainService.IRepositories;
using Pnprpg.DomainService.IServices;
using Pnprpg.DomainService.Models;

namespace Pnprpg.Domain.Services
{
    public class SkillService : BaseService, ISkillService
    {
        private readonly ISkillRepository _skillRepository;

        public SkillService(IMapper mapper, ISkillRepository skillRepository) : base(mapper)
        {
            _skillRepository = skillRepository;
        }
        
        public IQueryable<SkillViewModel> GetAll(MajorType major, int? filter = null)
        {
            var query = _skillRepository.Select(major).ProjectTo<SkillViewModel>(MapperConfig);
            return filter == null ? query : query.Where(x => (int) x.Type == filter);
        }

        public IQueryable<SkillViewModel> SelectSkills(MajorType major, SkillType? type, int ? branchId = null)
        {
            var skills = GetAll(major, (int?)type);
            if (branchId != null)
                skills = skills.Where(x => x.BranchId == branchId);
            return skills;
        }

        public HeroSkillGroup GetHeroSkillGroup(HeroModel hero)
        {
            var skills = GetAll(hero.Major).ToList();
            var skillGroup = new HeroSkillGroup(hero) {List = skills};
            foreach (var skill in skillGroup.List)
                skill.Level = hero.Skills.List.SingleOrDefault(x => x.Id == skill.Id)
                    ?.Level ?? 0;

            return skillGroup;
        }
        
        public SkillEditModel GetForEdit(int? id)
        {
            if (id == null)
                return new SkillEditModel();
            var model = _skillRepository.Get(id.Value).ProjectTo<SkillEditModel>(MapperConfig).FirstOrDefault();
            return model ?? new SkillEditModel();
        }

        public int Save(SkillEditModel model) => MappingSave(_skillRepository, model);

        public void Delete(int id) => _skillRepository.Delete(id);
    }
}
