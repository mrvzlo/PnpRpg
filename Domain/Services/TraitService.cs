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
    public class TraitService : BaseService, ITraitService
    {
        private readonly ITraitRepository _traitRepository;
        private readonly IEffectService _effectService;

        public TraitService(ITraitRepository traitRepository, IEffectService effectService)
        {
            _traitRepository = traitRepository;
            _effectService = effectService;
        }

        public List<TraitModel> GetAll()
        {
            var traits = _traitRepository.Select().ProjectTo<TraitModel>(MapperConfig).ToList();
            for (var i = 0; i < traits.Count; i++)
                traits[i] = _effectService.AssignEffects(traits[i]);

            return traits;
        }

        public TraitGroup GetForHero(HeroModel hero)
        {
            var list = GetAll().ToList();
            foreach (var trait in list.Where(trait => hero.Traits.List.Any(x => x.Id == trait.Id))) 
                trait.Level++;
            return new TraitGroup{ List = list };
        }

        public ServiceResponse<HeroModel> AssignTraitToHero(HeroModel hero, int traitId)
        {
            var response = new ServiceResponse<HeroModel>();
            var trait = GetTraitById(traitId);

            if (!hero.Traits.IsAssignable(trait) || !hero.ApplyEffectList(trait.Effects))
            {
                response.AddError(GenerationError.AbilitiesError.Description());
                return response;
            }

            trait.Level = 1;
            hero.Traits.List.Add(trait);
            response.Object = hero;
            return response;
        }

        public ServiceResponse<HeroModel> ResetTraitsForHero(HeroModel hero)
        {
            var service = new ServiceResponse<HeroModel>();
            hero.Traits.ResetTraits();
            service.Object = hero;
            return service;
        }

        private TraitModel GetTraitById(int id)
        {
            var trait = _traitRepository.Get(id);
            var model = Mapper.Map<TraitModel>(trait);
            return _effectService.AssignEffects(model);
        }
    }
}
