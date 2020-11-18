using System.Linq;
using System.Data.Entity;
using Pnprpg.DomainService.Entities;
using Pnprpg.DomainService.IRepositories;

namespace Pnprpg.Infrastructure.Repositories
{
    public class WeaponRepository : BaseRepository<Weapon>, IWeaponRepository
    {
        public WeaponRepository(AppDbContext dbContext) : base(dbContext) { }
        public override IQueryable<Weapon> Select() => base.Select().Include(x => x.Bonuses);
    }
}
