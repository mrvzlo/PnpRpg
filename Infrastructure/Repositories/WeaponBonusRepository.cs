using System.Data.Entity;
using System.Linq;
using Pnprpg.DomainService.Entities;
using Pnprpg.DomainService.IRepositories;

namespace Pnprpg.Infrastructure.Repositories
{
    public class WeaponBonusRepository : BaseRepository<WeaponBonus>, IWeaponBonusRepository
    {
        public WeaponBonusRepository(AppDbContext dbContext) : base(dbContext) { }

        public void ClearWeaponBonuses(int weaponId)
        {
            BatchDelete(DbContext.WeaponsBonuses.Where(x => x.WeaponId == weaponId));
        }
    }
}
