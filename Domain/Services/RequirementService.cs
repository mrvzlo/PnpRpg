using System.Collections.Generic;
using System.Linq;
using AutoMapper.QueryableExtensions;
using Pnprpg.DomainService.IRepositories;
using Pnprpg.DomainService.IServices;
using Pnprpg.DomainService.Models.Common;
using Pnprpg.DomainService.Models.Requirements;

namespace Pnprpg.Domain.Services
{
    public class RequirementService : BaseService, IRequirementService
    {
        private readonly IAbilityRepository _abilityRepository;
        private readonly IPerkRepository _perkRepository;
        private readonly IRaceRepository _raceRepository;

        public RequirementService(IPerkRepository perkRepository, IAbilityRepository abilityRepository, 
            IRaceRepository raceRepository)
        {
            _perkRepository = perkRepository;
            _abilityRepository = abilityRepository;
            _raceRepository = raceRepository;
        }

        public List<Selectable> GetVariants(AbilityRequirement requirement)
        {
            return _abilityRepository.Select().ProjectTo<Selectable>(MapperConfig).ToList();
        }

        public List<Selectable> GetVariants(PerkRequirement requirement)
        {
            return _perkRepository.Select().ProjectTo<Selectable>(MapperConfig).ToList();
        }

        public List<Selectable> GetVariants(RaceRequirement requirement)
        {
            return _raceRepository.Select().ProjectTo<Selectable>(MapperConfig).ToList();
        }
    }
}
