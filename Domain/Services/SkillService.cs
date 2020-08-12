using System.Linq;
using AutoMapper.QueryableExtensions;
using Pnprpg.DomainService.Enums;
using Pnprpg.DomainService.Helpers;
using Pnprpg.DomainService.IRepositories;
using Pnprpg.DomainService.IServices;
using Pnprpg.DomainService.Models;
using Pnprpg.DomainService.Models.Processing;
using Pnprpg.DomainService.Models.Skills;

namespace Pnprpg.Domain.Services
{
    public class SkillService : BaseService, ISkillService
    {
        private readonly ISkillGroupRepository _skillGroupRepository;
        private readonly ISkillRepository _skillRepository;

        public SkillService(ISkillGroupRepository skillGroupRepository, ISkillRepository skillRepository)
        {
            _skillGroupRepository = skillGroupRepository;
            _skillRepository = skillRepository;
        }

        public IQueryable<SkillGroupModel> GetAllGroups()
        {
            return _skillGroupRepository.Select().ProjectTo<SkillGroupModel>(MapperConfig);
        }

        public IQueryable<SkillModel> GetSkillsByGroup(int? groupId = null)
        {
            var skills = _skillRepository.Select();
            if (groupId != null)
                skills = skills.Where(x => x.GroupId == groupId);
            return skills.ProjectTo<SkillModel>(MapperConfig);
        }

        public HeroSkillGroup GetHeroSkillGroup(HeroModel hero)
        {
            var skills = GetSkillsByGroup();
            var skillGroup = new HeroSkillGroup(hero) {List = skills.ToList()};
            if (hero == null) 
                return skillGroup;

            foreach (var skill in skillGroup.List)
                skill.Level = hero.Skills.List.SingleOrDefault(x => x.Id == skill.Id)
                    ?.Level ?? 0;

            return skillGroup;
        }

        public ServiceResponse<HeroModel> UpgradeSkill(HeroModel hero, int skillId)
        {
            var response = new ServiceResponse<HeroModel>();
            var skill = GetSkillById(skillId);
            var success = hero.Skills.Update(skill);
            if (!success)
                response.AddError(GenerationError.AbilitiesError.Description());
            response.Object = hero;
            return response;
        }

        public HeroModel ResetSkills(HeroModel hero)
        {
            hero.Skills.Reset();
            return hero;
        }

        private SkillModel GetSkillById(int id)
        {
            var skill = _skillRepository.Get(id);
            return Mapper.Map<SkillModel>(skill);
        }
    }
}
