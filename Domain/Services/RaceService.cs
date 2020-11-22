using System;
using System.Collections.Generic;
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
    public class RaceService : BaseService, IRaceService
    {
        private readonly IRaceRepository _raceRepository;
        private readonly IBonusService _bonusService;
        private readonly IAbilityService _abilityService;

        public RaceService(IMapper mapper, IRaceRepository raceRepository, IBonusService bonusService, 
            IAbilityService abilityService) : base(mapper)
        {
            _raceRepository = raceRepository;
            _bonusService = bonusService;
            _abilityService = abilityService;
        }

        public IQueryable<RaceViewModel> GetAll(int? filter = null) =>
            _raceRepository.Select().ProjectTo<RaceViewModel>(MapperConfig);

        public RaceEditModel GetForEdit(int? id)
        {
            if (id == null)
                return new RaceEditModel();
            var model = _raceRepository.Get(id.Value).ProjectTo<RaceEditModel>(MapperConfig).FirstOrDefault();
            return model ?? new RaceEditModel();
        }

        public ServiceResponse<HeroModel> AssignRace(HeroModel hero, int raceId)
        {
            var response = new ServiceResponse<HeroModel>();
            var newRace = GetRace(raceId);
            if (newRace == null)
                return response.AddError("Раса не найдена");

            var oldRace = hero.Race != null ? GetRace(hero.Race.Id) : null;

            if (!hero.ApplyModifiers(GetRaceChangeEffects(oldRace, newRace)))
                return response.AddError(GenerationError.AbilitiesError.Description());

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

        public int Save(RaceEditModel model)
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

            return race.Id;
        }
        
        private RaceViewModel GetRace(int id)
        {
            var race = _raceRepository.Get(id).ProjectTo<RaceViewModel>(MapperConfig).First();
            return race;
        }

        private List<AbilityModifier> GetRaceChangeEffects(RaceViewModel oldRace, RaceViewModel newRace)
        {
            var modifiers = newRace.Modifiers;
            if (oldRace == null) 
                return modifiers;

            foreach (var x in oldRace.Modifiers)
                x.Revert();

            return modifiers.Concat(oldRace.Modifiers).ToList();
        }
    }
}
