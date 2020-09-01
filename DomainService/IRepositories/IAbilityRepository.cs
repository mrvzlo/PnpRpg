using System.Linq;
using Pnprpg.DomainService.Entities;

namespace Pnprpg.DomainService.IRepositories
{
    public interface IAbilityRepository : IBaseRepository<Ability>
    {
        void ClearRaceAbilities(int parentId);
        void InsertRaceAbilities(IQueryable<RaceAbility> abilities);
    }
}
