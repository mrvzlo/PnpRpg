using System;
using System.Linq;
using AutoMapper;
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
        private readonly IRaceAbilityRepository _raceAbilityRepository;
        private readonly IAbilityRepository _abilityRepository;

        public AbilityService(IMapper mapper, IRaceAbilityRepository raceAbilityRepository, IAbilityRepository abilityRepository) : base(mapper)
        {
            _raceAbilityRepository = raceAbilityRepository;
            _abilityRepository = abilityRepository;
        }
        
        public IQueryable<T> GetAll<T>(MajorType major) => _abilityRepository.Select(major).ProjectTo<T>(MapperConfig);

        public ServiceResponse<HeroModel> UpgradeAbility(HeroModel hero, AbilityType abilityType, int value)
        {
            var response = new ServiceResponse<HeroModel>();
            var success = hero.Abilities.Update(abilityType, value);
            if (!success)
                response = response.AddError(GenerationError.AbilitiesError.Description());
            response.Object = hero;
            return response;
        }

        public void BatchSave(IQueryable<RaceAbility> list, int parentId)
        {
            _raceAbilityRepository.ClearRaceAbilities(parentId);
            if (list == null || !list.Any())
                return;

            _raceAbilityRepository.InsertRaceAbilities(list);
        }

        public void BatchClear(int parentId)
        {
            _raceAbilityRepository.ClearRaceAbilities(parentId);
        }

        public void Delete(int id) => _abilityRepository.Delete(id);

        public AbilityEditModel GetForEdit(int? id)
        {
            if (id == null)
                return new AbilityEditModel();
            var model = _abilityRepository.Get(id.Value).ProjectTo<AbilityEditModel>(MapperConfig).FirstOrDefault();
            return model ?? new AbilityEditModel();
        }

        public int Save(AbilityEditModel model) => MappingSave(_abilityRepository, model);
    }
}
