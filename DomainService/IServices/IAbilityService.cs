using System.Linq;
using Pnprpg.DomainService.Entities;
using Pnprpg.DomainService.Enums;
using Pnprpg.DomainService.Models;

namespace Pnprpg.DomainService.IServices
{
    public interface IAbilityService
    {
        IQueryable<T> GetAll<T>(MajorType major);
        ServiceResponse<HeroModel> UpgradeAbility(HeroModel hero, AbilityType abilityType, int value);
        void BatchSave(IQueryable<RaceAbility> list, int parentId);
        void BatchClear(int parentId);
    }
}
