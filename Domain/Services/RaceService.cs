using System;
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
    public class RaceService : BaseService, IRaceService
    {
        private readonly IRaceRepository _raceRepository;
        private readonly IEffectService _effectService;
        private readonly IBonusService _bonusService;
        private readonly IAbilityService _abilityService;

        public RaceService(IRaceRepository raceRepository, IEffectService effectService, IBonusService bonusService, IAbilityService abilityService)
        {
            _raceRepository = raceRepository;
            _effectService = effectService;
            _bonusService = bonusService;
            _abilityService = abilityService;
        }

        public IQueryable<RaceViewModel> GetAll() =>
            _raceRepository.Select().ProjectTo<RaceViewModel>(MapperConfig);

        public RaceEditModel GetForEdit(int? id)
        {
            var race = id != null ? _raceRepository.Get(id.Value) : new Race();
            return Mapper.Map<RaceEditModel>(race);
        }

        public ServiceResponse<HeroModel> AssignRace(HeroModel hero, int raceId)
        {
            var response = new ServiceResponse<HeroModel>();
            var newRace = GetRace(raceId);
            var oldRace = hero.Race != null ? GetRace(hero.Race.Id) : null;

            if (!hero.ApplyEffectList(GetRaceChangeEffects(oldRace, newRace)))
            {
                response.AddError(GenerationError.AbilitiesError.Description());
                return response;
            }

            hero.Race = newRace;
            response.Object = hero;
            return response;
        }

        public void Delete(int id)
        {
            _bonusService.BatchClear(id, BonusType.Race);
            _abilityService.BatchClear(id);
            _raceRepository.Delete(id);
        }

        public void Save(RaceEditModel model)
        {
            var race = new Race
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description
            };

            race.Id = _raceRepository.InsertOrUpdate(race);

            var bonuses = model.Bonuses?.Select(x => new RaceBonus
            {
                RaceId = model.Id,
                BonusId = x
            }).AsQueryable();
            _bonusService.BatchSave(bonuses, race.Id, BonusType.Race);

            var abilities = model.Abilities?.Select(x => new RaceAbility()
            {
                RaceId = model.Id,
                AbilityId = x.Id,
                Value = x.Value
            }).AsQueryable();
            _abilityService.BatchSave(abilities, race.Id);
        }


        private RaceViewModel GetRace(int id)
        {
            var race = _raceRepository.Get(id);
            var model = Mapper.Map<RaceViewModel>(race);
            return _effectService.AssignEffects(model);
        }

        private List<EffectDescModel> GetRaceChangeEffects(RaceViewModel oldRace, RaceViewModel newRace)
        {
            var effects = newRace.Effects;
            if (oldRace == null) 
                return effects;

            foreach (var effect in oldRace.Effects)
                effect.Revert();

            return newRace.Effects.Concat(oldRace.Effects).ToList();
        }
    }
}
