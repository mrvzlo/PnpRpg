using System;
using System.Text;
using Newtonsoft.Json;
using Pnprpg.DomainService.Helpers;
using Pnprpg.DomainService.Models;

namespace Pnprpg.Domain.Services
{
    public class Encoder
    {
        private const char Separator = '_';

        public string EncodeHero(HeroModel hero)
        {
            hero = Trim(hero);
            var encoded = JsonConvert.SerializeObject(hero);
            encoded =  $"{Constants.Version}{Separator}{encoded}";
            var bytes = Encoding.UTF8.GetBytes(encoded);
            return Convert.ToBase64String(bytes);
        }

        public HeroModel DecodeHero(string base64)
        {
            if (string.IsNullOrEmpty(base64))
                return null;

            var bytes = Convert.FromBase64String(base64);
            var encoded = Encoding.UTF8.GetString(bytes);
            if (string.IsNullOrEmpty(encoded))
                return null;

            var splitted = encoded.Split(Separator);
            if (splitted.Length < 2 || splitted[0] != Constants.Version)
                return null;
            var hero = JsonConvert.DeserializeObject<HeroModel>(splitted[1]);
            return hero;
        }

        public HeroModel Trim(HeroModel hero)
        {
            hero.Race.Effects = null;
            foreach (var trait in hero.Traits.List) 
                trait.Effects = null;

            return hero;
        }
    }
}
