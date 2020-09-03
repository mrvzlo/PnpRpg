using System;
using System.Linq;
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
        private readonly IRaceService _raceService;
        private readonly Encoder _encoder;

        public CoreLogic(IUserRepository userRepository, IAbilityService abilityService, IRaceService raceService)
        {
            _userRepository = userRepository;
            _abilityService = abilityService;
            _raceService = raceService;
            _encoder = new Encoder();
        }

        public HeroModel CreateHero(Company chaos)
        {
            var hero = new HeroModel(chaos);
            var abilities = _abilityService.GetAll<AbilityModel>();
            hero.Abilities.List = abilities.ToList();
            hero.Abilities.Setup(chaos);
            hero.MaxStatus = 0;
            return hero;
        }

        public string EncodeHero(HeroModel hero, string version) => _encoder.EncodeHero(hero, version);

        public HeroModel DecodeHero(string data, string version) => _encoder.DecodeHero(data, version);

        public HeroModel LoadHero(string username)
        {
            var user = _userRepository.GetUserByName(username);
            //todo
            throw new System.NotImplementedException();
        }

        public bool SaveHero(HeroModel hero)
        {
            var user = _userRepository.GetUserByName(hero.Player);
            throw new System.NotImplementedException();
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
    }
}