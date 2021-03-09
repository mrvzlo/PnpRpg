using System.Linq;
using System.Data.Entity;
using Pnprpg.DomainService.Entities;
using Pnprpg.DomainService.Enums;
using Pnprpg.DomainService.IRepositories;

namespace Pnprpg.Infrastructure.Repositories
{
    public class WeaponRepository : BaseSettingPartRepository<Weapon>, IWeaponRepository
    {
        public WeaponRepository(AppDbContext dbContext) : base(dbContext) { }
        public override IQueryable<Weapon> Select(MajorType major)
        {
            return base.Select(major).Include(x => x.Bonuses);
        }
    }
}
