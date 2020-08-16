using System.Collections.Generic;
using System.Linq;
using AutoMapper.QueryableExtensions;
using Pnprpg.DomainService.Enums;
using Pnprpg.DomainService.IRepositories;
using Pnprpg.DomainService.IServices;
using Pnprpg.DomainService.Models;

namespace Pnprpg.Domain.Services
{
    public class EffectService : BaseService, IEffectService
    {
        private readonly IEffectRepository _effectRepository;
        private readonly IAbilityService _abilityService;

        public EffectService(IEffectRepository effectRepository, IAbilityService abilityService)
        {
            _effectRepository = effectRepository;
            _abilityService = abilityService;
        }

        public RaceModel AssignEffects(RaceModel target)
        {
            target.Effects = GetEffects(target.Id, AssignableType.Race);
            return target;
        }

        public TraitModel AssignEffects(TraitModel target)
        {
            target.Effects = GetEffects(target.Id, AssignableType.Trait);
            return target;
        }

        private List<EffectDescModel> GetEffects(int targetId, AssignableType parentType)
        {
            var effects = _effectRepository.Select().ProjectTo<EffectDescModel>(MapperConfig).ToList();
            var abilities = _abilityService.GetAll().ToList();
            foreach (var effect in effects.Where(x => x.TargetType == EffectTarget.Ability))
                effect.Target = abilities.Single(x => x.Id == effect.TargetId);

            return effects.Where(x => x.ParentId == targetId && x.ParentType == parentType).ToList();
        }
    }
}
