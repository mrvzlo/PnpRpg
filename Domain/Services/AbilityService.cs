using System.Linq;
using AutoMapper.QueryableExtensions;
using Pnprpg.DomainService.Enums;
using Pnprpg.DomainService.Helpers;
using Pnprpg.DomainService.IRepositories;
using Pnprpg.DomainService.IServices;
using Pnprpg.DomainService.Models;
using Pnprpg.DomainService.Models.Abilities;
using Pnprpg.DomainService.Models.Processing;

namespace Pnprpg.Domain.Services
{
    public class AbilityService : BaseService, IAbilityService
    {
        private readonly IAbilityRepository _abilityRepository;

        public AbilityService(IAbilityRepository abilityRepository)
        {
            _abilityRepository = abilityRepository;
        }

        public IQueryable<AbilityDescriptionModel> GetAllWithDescription()
        {
            return _abilityRepository.Select().ProjectTo<AbilityDescriptionModel>(MapperConfig);
        }

        public IQueryable<AbilityModel> GetAll()
        {
            return _abilityRepository.Select().ProjectTo<AbilityModel>(MapperConfig);
        }

        public ServiceResponse<HeroModel> UpgradeAbility(HeroModel hero, int ability, int value)
        {
            var response = new ServiceResponse<HeroModel>();
            var success= hero.Abilities.Update(ability, value);
            if (!success)
                response.AddError(GenerationError.AbilitiesError.Description());
            response.Object = hero;
            return response;
        }
    }
}
