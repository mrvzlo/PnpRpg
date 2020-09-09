using System;
using System.Text;
using Newtonsoft.Json;
using Pnprpg.DomainService.Models;

namespace Pnprpg.Domain.Services
{
    public class Encoder
    {
        private const char Separator = '_';

        public string EncodeHero(HeroModel hero, string version)
        {
            hero = Trim(hero);
            var encoded = JsonConvert.SerializeObject(hero);
            encoded = $"{version}{Separator}{encoded}";
            var bytes = Encoding.UTF8.GetBytes(encoded);
            return Convert.ToBase64String(bytes);
        }

        public HeroModel DecodeHero(string base64, string version)
        {
            if (string.IsNullOrEmpty(base64))
                return null;

            var bytes = Convert.FromBase64String(base64);
            var encoded = Encoding.UTF8.GetString(bytes);
            if (string.IsNullOrEmpty(encoded))
                return null;

            var splitted = encoded.Split(Separator);
            if (splitted.Length < 2 || splitted[0] != version)
                return null;
            var hero = JsonConvert.DeserializeObject<HeroModel>(splitted[1]);
            hero.Abilities.SetLimit();
            return hero;
        }

        public HeroModel Trim(HeroModel hero)
        {
            hero.Skills.List.RemoveAll(x => x.Level == 0);
            hero.Race.Trim();
            foreach (var trait in hero.Traits.List)
                trait.Effects = null;
            foreach (var skill in hero.Skills.List)
                skill.Trim();
            foreach (var branch in hero.Branches.List) 
                branch.Trim();

            return hero;
        }
    }
}
