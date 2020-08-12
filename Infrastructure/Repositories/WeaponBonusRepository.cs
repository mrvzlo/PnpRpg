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
            foreach (var weapon in DbContext.WeaponsBonuses.Where(x => x.WeaponId == weaponId))
                    DbContext.Entry(weapon).State = EntityState.Deleted;
            DbContext.SaveChanges();
        }
    }
}
