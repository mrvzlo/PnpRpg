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

        public TraitService(ITraitRepository traitRepository)
        {
            _traitRepository = traitRepository;
        }

        public IQueryable<TraitModel> GetAll() =>
            _traitRepository.Select().ProjectTo<TraitModel>(MapperConfig);

        public TraitGroup GetForHero(HeroModel hero)
        {
            var list = GetAll().ToList();
            foreach (var trait in list.Where(trait => hero.Traits.List.Any(x => x.Id == trait.Id)))
                trait.Level++;
            return new TraitGroup { List = list };
        }

        public ServiceResponse<HeroModel> AssignTraitToHero(HeroModel hero, int traitId)
        {
            var response = new ServiceResponse<HeroModel>();
            var trait = GetTraitById(traitId);

            if (!hero.Traits.IsAssignable(trait) || !hero.ApplyEffectList(trait.Effects, false))
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
            var effects = GetForHero(hero).List.Where(x => x.IsAssigned()).SelectMany(x => x.Effects).ToList();
            foreach (var effect in effects)
                effect.Revert();
            hero.ApplyEffectList(effects, false);
            hero.Traits.Reset();
            service.Object = hero;
            return service;
        }

        private TraitModel GetTraitById(int id)
        {
            var trait = _traitRepository.Get(id);
            return Mapper.Map<TraitModel>(trait);
        }
    }
}
