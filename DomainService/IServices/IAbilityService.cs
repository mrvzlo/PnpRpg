using System.Linq;
using Pnprpg.DomainService.Models;

namespace Pnprpg.DomainService.IServices
{
    public interface IAbilityService
    {
        IQueryable<AbilityDescriptionModel> GetAllWithDescription();
        IQueryable<AbilityModel> GetAll();
        ServiceResponse<HeroModel> UpgradeAbility(HeroModel hero, int ability, int value);
    }
}
