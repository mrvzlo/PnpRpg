using System.Linq;
using Pnprpg.DomainService.Entities;
using Pnprpg.DomainService.Models;

namespace Pnprpg.DomainService.IServices
{
    public interface IAbilityService
    {
        IQueryable<T> GetAll<T>();
        ServiceResponse<HeroModel> UpgradeAbility(HeroModel hero, int ability, int value);
        void BatchSave(IQueryable<RaceAbility> list, int parentId);
        void BatchClear(int parentId);
    }
}
