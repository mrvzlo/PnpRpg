using System;
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
        SelectableList ToSelectableList(IQueryable<object> list, object selected = null);
        SelectableList ToSelectableList(Enum[] query, object selected = null);
    }
}
