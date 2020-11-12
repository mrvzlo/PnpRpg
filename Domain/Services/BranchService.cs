using System.Collections.Generic;
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
    public class BranchService : BaseService, IBranchService
    {
        private readonly IBranchRepository _branchRepository;
        private readonly IBonusService _bonusService;
        private readonly IPerkService _perkService;

        public BranchService(IBranchRepository branchRepository, IBonusService bonusService, IPerkService perkService)
        {
            _branchRepository = branchRepository;
            _bonusService = bonusService;
            _perkService = perkService;
        }

        public IQueryable<BranchViewModel> GetAll() => 
            _branchRepository.Select().ProjectTo<BranchViewModel>(MapperConfig);

        public List<BranchViewModel> GetAllWithPerks()
        {
            var branches = _branchRepository.Select().ProjectTo<BranchViewModel>(MapperConfig).ToList();
            foreach (var branch in branches)
                branch.Perks = branch.Perks.SelectMany(x => _perkService.GetPerkRanks(x)).ToList();

            return branches;
        }

        public BranchViewModel Get(int id)
        {
            var race = _branchRepository.Get(id);
            return Mapper.Map<BranchViewModel>(race);
        }

        public BranchEditModel GetForEdit(int? id)
        {
            var race = id != null ? _branchRepository.Get(id.Value) : new Branch();
            return Mapper.Map<BranchEditModel>(race);
        }

        public void Delete(int id)
        {
            _bonusService.BatchClear(id, BonusType.Branch);
            _branchRepository.Delete(id);
        }

        public void Save(BranchEditModel model)
        {
            var branch = new Branch
            {
                Id = model.Id,
                Name = model.Name,
                Color = model.Color,
                Description = model.Description,
                ShortDescription = model.ShortDescription
            };

            branch.Id = _branchRepository.InsertOrUpdate(branch);

            var bonuses = model.Bonuses?.Select(x => new BranchBonus
            {
                BranchId = model.Id,
                BonusId = x
            }).AsQueryable();

            _bonusService.BatchSave(bonuses, branch.Id, BonusType.Branch);
        }

        public ServiceResponse<HeroModel> Assign(HeroModel hero, int branchId, int pos)
        {
            var response = new ServiceResponse<HeroModel>();
            var newBranch = Get(branchId);
            var oldBranch = hero.Branches?.List.Skip(pos).FirstOrDefault();
            var effects = SkillListToEffects(newBranch.Skills.ToList());
            if (oldBranch != null)
            {
                oldBranch = Get(oldBranch.Id);
                effects.AddRange(SkillListToEffects(oldBranch.Skills.ToList(), true));
            }

            hero.ApplyEffectList(effects, false);
            if (oldBranch != null)
                hero.Branches.List.RemoveAt(pos);
            hero.Branches.List.Add(newBranch);
            response.Object = hero;
            return response;
        }

        private List<TraitEffectDescModel> SkillListToEffects(List<SkillViewModel> skills, bool revert = false) =>
            skills.Select(x => new TraitEffectDescModel
            {
                Skill = x,
                TargetType = EffectTarget.Skill,
                TargetId = x.Id,
                Value = revert ? -1 : 1
            }).ToList();
    }
}
