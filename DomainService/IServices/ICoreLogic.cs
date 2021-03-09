using System;
using System.Collections.Generic;
using System.Linq;
using Pnprpg.DomainService.Enums;
using Pnprpg.DomainService.Models;

namespace Pnprpg.DomainService.IServices
{
    public interface ICoreLogic
    {
        HeroModel CreateHero(MajorType major);
        string EncodeHero(HeroModel hero, MajorType major);
        HeroModel DecodeHero(string data, MajorType major);
        HeroModel GetFullHeroInfo(HeroModel hero);
        List<Selectable> ToSelectableList(IQueryable<object> list, string selected = null, bool addDefault = false);
        List<Selectable> ToSelectableList(IEnumerable<Enum> query, string selected = null, bool addDefault = false);
    }
}
