using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Pnprpg.DomainService.Enums;
using Pnprpg.DomainService.Helpers;
using Pnprpg.DomainService.IServices;
using Pnprpg.DomainService.Models;

namespace Pnprpg.Domain.Services
{
    public class CoreLogic : BaseService, ICoreLogic
    {
        private readonly IAbilityService _abilityService;
        private readonly ISkillService _skillService;
        private readonly IRaceService _raceService;
        private readonly IBranchService _branchService;
        private readonly ITraitService _traitService;
        private readonly IMajorService _majorService;
        private readonly Encoder _encoder;

        public CoreLogic(IMapper mapper, IAbilityService abilityService, IRaceService raceService, 
            IBranchService branchService, ISkillService skillService, ITraitService traitService, IMajorService majorService) : base(mapper)
        {
            _abilityService = abilityService;
            _raceService = raceService;
            _branchService = branchService;
            _skillService = skillService;
            _traitService = traitService;
            _majorService = majorService;
            _encoder = new Encoder();
        }

        public HeroModel CreateHero(MajorType major)
        {
            var hero = new HeroModel(major);
            var abilities = _abilityService.GetAll<AbilityModel>(major);
            hero.Abilities.List = abilities.ToList();
            var settings = _majorService.GetSettings((int)major);
            hero.Abilities.Setup(settings);
            hero.MaxStage = 0;
            return hero;
        }

        public string EncodeHero(HeroModel hero, MajorType major)
        {
            var version = _majorService.GetVersion((int) major);
            return _encoder.EncodeHero(hero, version);
        }

        public HeroModel DecodeHero(string data, MajorType major)
        {
            var version = _majorService.GetVersion((int)major);
            var hero = _encoder.DecodeHero(data, version);
            return hero == null ? null : GetFullHeroInfo(hero);
        }

        public List<Selectable> ToSelectableList(IQueryable<object> query, string selected = null, bool addDefault = false)
        {
            var list = query.ProjectTo<Selectable>(MapperConfig).ToList();
            return CompleteSelectableList(list, selected, addDefault);
        }

        public List<Selectable> ToSelectableList(IEnumerable<Enum> query, string selected = null, bool addDefault = false)
        {
            var list = query.Select(x => new Selectable(x, x.Description())).ToList();
            return CompleteSelectableList(list, selected, addDefault);
        }

        private List<Selectable> CompleteSelectableList(List<Selectable> list, string selected, bool addDefault)
        {
            foreach (var x in list)
                x.Selected = x.Value == selected;
            if (addDefault)
                list.Insert(0, new Selectable(string.Empty, "-Не выбрано-"));
            return list;
        }

        public HeroModel GetFullHeroInfo(HeroModel hero)
        {
            hero.Skills = _skillService.GetHeroSkillGroup(hero);
            hero.Race = _raceService.GetAll(hero.Major).FirstOrDefault(x => x.Id == hero.Race.Id);
            var branches = hero.Branches.List.Select(y => y.Id);
            hero.Branches.List = _branchService.GetAll(hero.Major).Where(x => branches.Contains(x.Id)).ToList();
            hero.Traits.List = _traitService.GetForHero(hero).List.Where(x => x.IsAssigned()).ToList();
            return hero;
        }
    }
}