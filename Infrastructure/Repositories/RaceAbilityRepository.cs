using System.Linq;
using Microsoft.EntityFrameworkCore;
using Pnprpg.DomainService.Entities;
using Pnprpg.DomainService.IRepositories;

namespace Pnprpg.Infrastructure.Repositories
{
    public class RaceAbilityRepository : BaseRepository<RaceAbility>, IRaceAbilityRepository
    {
        public RaceAbilityRepository(AppDbContext dbContext) : base(dbContext) { }

        public void ClearRaceAbilities(int parentId)
        {
            foreach (var entity in DbContext.RaceAbilities.Where(x => x.RaceId == parentId))
                DbContext.Entry(entity).State = EntityState.Deleted;

            DbContext.SaveChanges();
        }

        public void InsertRaceAbilities(IQueryable<RaceAbility> abilities)
        {
            foreach (var entity in abilities)
                DbContext.Entry(entity).State = EntityState.Added;

            DbContext.SaveChanges();
        }
    }
}
