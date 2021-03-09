using System.Linq;
using Pnprpg.DomainService.Entities;
using Pnprpg.DomainService.Enums;

namespace Pnprpg.DomainService.IRepositories
{
    public interface IBonusRepository : IBaseSettingPartRepository<Bonus>
    {
        void ClearBonuses(int parentId, BonusType type);
        void BatchInsertBonuses(IQueryable<BaseBonusJoin> bonuses);
    }
}
