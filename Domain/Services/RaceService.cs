using System.Collections.Generic;
using System.Linq;
using AutoMapper.QueryableExtensions;
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

        public RaceService(IRaceRepository raceRepository, IEffectService effectService)
        {
            _raceRepository = raceRepository;
            _effectService = effectService;
        }

        public List<RaceModel> GetAll()
        {
            var races = _raceRepository.Select().ProjectTo<RaceModel>(MapperConfig).ToList();
            for (var i = 0; i < races.Count; i++) 
                races[i] = _effectService.AssignEffects(races[i]);

            return races;
        }

        public ServiceResponse<HeroModel> AssignRace(HeroModel hero, int raceId)
        {
            var response = new ServiceResponse<HeroModel>();
            var newRace = GetRace(raceId);
            var oldRace = GetRace(hero.Race.Id);

            if (!hero.ApplyEffectList(GetRaceChangeEffects(oldRace, newRace)))
            {
                response.AddError(GenerationError.AbilitiesError.Description());
                return response;
            }

            hero.Race = newRace;
            response.Object = hero;
            return response;
        }

        private RaceModel GetRace(int id)
        {
            var race = _raceRepository.Get(id);
            var model = Mapper.Map<RaceModel>(race);
            return _effectService.AssignEffects(model);
        }


        private List<EffectDescModel> GetRaceChangeEffects(RaceModel oldRace, RaceModel newRace)
        {
            foreach (var effect in oldRace.Effects)
                effect.Revert();

            return newRace.Effects.Concat(oldRace.Effects).ToList();
        }
    }
}
