using System.Linq;
using Pnprpg.DomainService.Models;

namespace Pnprpg.DomainService.IServices
{
    public interface IAbilityService
    {
        IQueryable<T> GetAll<T>();
        ServiceResponse<HeroModel> UpgradeAbility(HeroModel hero, int ability, int value);
    }
}
