using System;
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
    public class AbilityService : BaseService, IAbilityService
    {
        private readonly IAbilityRepository _abilityRepository;

        public AbilityService(IAbilityRepository abilityRepository)
        {
            _abilityRepository = abilityRepository;
        }
        
        public IQueryable<T> GetAll<T>() => _abilityRepository.Select().ProjectTo<T>(MapperConfig);

        public ServiceResponse<HeroModel> UpgradeAbility(HeroModel hero, int ability, int value)
        {
            var response = new ServiceResponse<HeroModel>();
            var success= hero.Abilities.Update(ability, value);
            if (!success)
                response.AddError(GenerationError.AbilitiesError.Description());
            response.Object = hero;
            return response;
        }

        public void BatchSave(IQueryable<RaceAbility> list, int parentId)
        {
            _abilityRepository.ClearRaceAbilities(parentId);
            if (list == null || !list.Any())
                return;

            _abilityRepository.InsertRaceAbilities(list);
        }

        public void BatchClear(int parentId)
        {
            _abilityRepository.ClearRaceAbilities(parentId);
        }
    }
}
