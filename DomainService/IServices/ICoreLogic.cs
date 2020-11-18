using System;
using System.Collections.Generic;
using System.Linq;
using Pnprpg.DomainService.Enums;
using Pnprpg.DomainService.Models;

namespace Pnprpg.DomainService.IServices
{
    public interface ICoreLogic
    {
        HeroModel CreateHero(Company chaos);
        string EncodeHero(HeroModel hero, string version);
        HeroModel DecodeHero(string data, string version);
        HeroModel GetFullHeroInfo(HeroModel hero);
        List<Selectable> ToSelectableList(IQueryable<object> list, string selected = null);
        List<Selectable> ToSelectableList(IEnumerable<Enum> query, string selected = null);
    }
}
