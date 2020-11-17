using System;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Pnprpg.DomainService.Enums;
using Pnprpg.DomainService.Helpers;
using Pnprpg.DomainService.IRepositories;
using Pnprpg.DomainService.IServices;
using Pnprpg.DomainService.Models;

namespace Pnprpg.Domain.Services
{
    public class CoreLogic : BaseService, ICoreLogic
    {
        private readonly IUserRepository _userRepository;
        private readonly IAbilityService _abilityService;
        private readonly ISkillService _skillService;
        private readonly IRaceService _raceService;
        private readonly IBranchService _branchService;
        private readonly ITraitService _traitService;
        private readonly Encoder _encoder;

        public CoreLogic(IMapper mapper, IUserRepository userRepository, IAbilityService abilityService, IRaceService raceService, 
            IBranchService branchService, ISkillService skillService, ITraitService traitService) : base(mapper)
        {
            _userRepository = userRepository;
            _abilityService = abilityService;
            _raceService = raceService;
            _branchService = branchService;
            _skillService = skillService;
            _traitService = traitService;
            _encoder = new Encoder();
        }

        public HeroModel CreateHero(Company chaos)
        {
            var hero = new HeroModel(chaos);
            var abilities = _abilityService.GetAll<AbilityModel>();
            hero.Abilities.List = abilities.ToList();
            hero.Abilities.Setup(chaos);
            hero.MaxStage = 0;
            return hero;
        }

        public string EncodeHero(HeroModel hero, string version) => _encoder.EncodeHero(hero, version);

        public HeroModel DecodeHero(string data, string version)
        {
            var hero = _encoder.DecodeHero(data, version);
            return hero == null ? null : GetFullHeroInfo(hero);
        }

        public SelectableList ToSelectableList(IQueryable<object> query, object selected = null)
        {
            var list = query.ProjectTo<Selectable>(MapperConfig).ToList();
            return new SelectableList(list, selected);
        }

        public SelectableList ToSelectableList(Enum[] query, object selected = null)
        {
            var list = query.Select(x => new Selectable(x, x.Description())).ToList();
            return new SelectableList(list, selected);
        }

        public HeroModel GetFullHeroInfo(HeroModel hero)
        {
            hero.Skills = _skillService.GetHeroSkillGroup(hero);
            hero.Race = _raceService.GetAll().FirstOrDefault(x => x.Id == hero.Race.Id);
            var branches = hero.Branches.List.Select(y => y.Id);
            hero.Branches.List = _branchService.GetAll().Where(x => branches.Contains(x.Id)).ToList();
            hero.Traits.List = _traitService.GetForHero(hero).List.Where(x => x.IsAssigned()).ToList();
            return hero;
        }
    }
}