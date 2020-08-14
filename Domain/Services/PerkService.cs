using System.Collections.Generic;
using System.Linq;
using AutoMapper.QueryableExtensions;
using Pnprpg.DomainService.Entities;
using Pnprpg.DomainService.Enums;
using Pnprpg.DomainService.IRepositories;
using Pnprpg.DomainService.IServices;
using Pnprpg.DomainService.Models.Perks;
using Pnprpg.DomainService.Models.Requirements;

namespace Pnprpg.Domain.Services
{
    public class PerkService : BaseService, IPerkService
    {
        private readonly IPerkRepository _perkRepository;
        private readonly IPerkBranchRepository _perkBranchRepository;
        private readonly IRequirementRepository _requirementRepository;
        
        public PerkService(IPerkRepository perkRepository, IRequirementRepository requirementRepository, IPerkBranchRepository perkBranchRepository)
        {
            _perkRepository = perkRepository;
            _requirementRepository = requirementRepository;
            _perkBranchRepository = perkBranchRepository;
        }

        public IQueryable<PerkViewModel> GetAll()
        {
            return _perkRepository.Select().ProjectTo<PerkViewModel>(MapperConfig);
        }

        public IQueryable<PerkBranchModel> GetAllBranches()
        {
            return _perkBranchRepository.Select().ProjectTo<PerkBranchModel>(MapperConfig);
        }
        
        public PerkEditModel GetForEdit(int? id)
        {
            if (id == null)
                return new PerkEditModel();
            var perk = _perkRepository.Get(id.Value);
            return perk != null ? Mapper.Map<PerkEditModel>(perk) : new PerkEditModel();
        }

        public void SavePerk(PerkEditModel model)
        {
            var perk = new Perk
            {
                Id = model.Id,
                Description = model.Description,
                Name = model.Name,
                BranchId = model.BranchId,
                Max = model.Max
            };

            model.Id = _perkRepository.InsertOrUpdate(perk);
            SaveRequirements(model);
        }

        public void DeletePerk(int id)
        {
            _requirementRepository.ClearPerkRequirements(id);
            _perkRepository.Delete(id);
        }

        private void SaveRequirements(PerkEditModel model)
        {
            _requirementRepository.ClearPerkRequirements(model.Id);

            model.RequirementsForPerks ??= new List<RequirementCommonModel>();
            model.RequirementsForPerks.Add(new RequirementCommonModel
            {
                Type = RequirementType.Level, Value = model.Level
            });

            var requirements = model.RequirementsForPerks.Select(x => new RequirementForPerk
                {
                    PerkId = model.Id,
                    AbilityId = x.AbilityId,
                    Type = x.Type,
                    Value = x.Value
                }).AsQueryable();
            
            _requirementRepository.BatchInsert(requirements);
        }
    }
}
