using System.Linq;
using Pnprpg.DomainService.Entities;

namespace Pnprpg.DomainService.IRepositories
{
    public interface IRaceAbilityRepository : IBaseRepository<RaceAbility>
    {
        void ClearRaceAbilities(int parentId);
        void InsertRaceAbilities(IQueryable<RaceAbility> abilities);
    }
}
