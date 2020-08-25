using System.Linq;
using Pnprpg.DomainService.Enums;
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

        public HeroModel CreateHero(ChaosLevel chaos)
        {
            var hero = new HeroModel(chaos);
            var abilities = _abilityService.GetAll<AbilityModel>();
            hero.Abilities.List = abilities.ToList();
            hero.Abilities.Setup(chaos);
            if (chaos != ChaosLevel.Null)
                hero.Race = _raceService.GetAll().First();
            return hero;
        }

        public string EncodeHero(HeroModel hero)
        {
            return _encoder.EncodeHero(hero);
        }

        public HeroModel DecodeHero(string data)
        {
            return _encoder.DecodeHero(data);
        }

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
    }
}