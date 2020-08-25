using System.Linq;
using AutoMapper.QueryableExtensions;
using Pnprpg.DomainService.Entities;
using Pnprpg.DomainService.Enums;
using Pnprpg.DomainService.Helpers;
using Pnprpg.DomainService.IRepositories;
using Pnprpg.DomainService.IServices;
using Pnprpg.DomainService.Models;

namespace Pnprpg.Domain.Services
{
    public class SkillService : BaseService, ISkillService
    {
        private readonly ISkillRepository _skillRepository;

        public SkillService(ISkillRepository skillRepository)
        {
            _skillRepository = skillRepository;
        }
        
        public IQueryable<SkillViewModel> GetAll() => SelectSkills();

        public IQueryable<SkillViewModel> SelectSkills(int? branchId = null, SkillType? type = null)
        {
            var skills = _skillRepository.Select();
            if (branchId != null)
                skills = skills.Where(x => x.BranchId == branchId);
            if (type != null)
                skills = skills.Where(x => x.Type == type);
            return skills.ProjectTo<SkillViewModel>(MapperConfig);
        }

        public HeroSkillGroup GetHeroSkillGroup(HeroModel hero)
        {
            var skills = GetAll();
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

        private SkillViewModel GetSkillById(int id)
        {
            var skill = _skillRepository.Get(id);
            return Mapper.Map<SkillViewModel>(skill);
        }

        public SkillEditModel GetForEdit(int? id)
        {
            var skill = id != null
                ? _skillRepository.Get(id.Value)
                : new SkillInfo();

            return Mapper.Map<SkillEditModel>(skill);
        }

        public void Save(SkillEditModel model)
        {
            var skill = new SkillInfo
            {
                Id = model.Id,
                Difficulty = model.Difficulty,
                AbilityId = model.AbilityId,
                BranchId = model.BranchId,
                Type = model.Type,
                Name = model.Name
            };

            _skillRepository.InsertOrUpdate(skill);
        }

        public void Delete(int id)
        {
            _skillRepository.Delete(id);
        }
    }
}
