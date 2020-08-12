using System.Collections.Generic;
using System.Linq;
using AutoMapper.QueryableExtensions;
using Pnprpg.DomainService.Entities;
using Pnprpg.DomainService.IRepositories;
using Pnprpg.DomainService.IServices;
using Pnprpg.DomainService.Models.Perks;
using Pnprpg.DomainService.Models.Requirements;

namespace Pnprpg.Domain.Services
{
    public class PerkService : BaseService, IPerkService
    {
        private readonly IPerkRepository _perkRepository;
        private readonly IRequirementRepository _requirementRepository;
        
        public PerkService(IPerkRepository perkRepository, IRequirementRepository requirementRepository)
        {
            _perkRepository = perkRepository;
            _requirementRepository = requirementRepository;
        }

        public IQueryable<PerkViewModel> GetAll()
        {
            return _perkRepository.Select().ProjectTo<PerkViewModel>(MapperConfig);
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
                Name = model.Name
            };

            _perkRepository.InsertOrUpdate(perk);
            SaveRequirements(model.Requirements, model.Id);
        }

        public void DeletePerk(int id)
        {
            _perkRepository.Delete(id);
        }

        private void SaveRequirements(List<RequirementCommonModel> list, int perkId)
        {
            _requirementRepository.ClearPerkRequirements(perkId);
            if (list == null)
                return;

            var requirements = list.Select(x => new RequirementForPerk
                {
                    PerkId = perkId,
                    AbilityId = x.AbilityId,
                    Type = x.Type,
                    Value = x.Value
                }).AsQueryable();
            
            _requirementRepository.BatchInsert(requirements);
        }
    }
}
