using System.Linq;
using Microsoft.EntityFrameworkCore;
using Pnprpg.DomainService.Entities;
using Pnprpg.DomainService.Enums;
using Pnprpg.DomainService.IRepositories;

namespace Pnprpg.Infrastructure.Repositories
{
    public class BonusRepository : BaseRepository<Bonus>, IBonusRepository
    {
        public BonusRepository(AppDbContext dbContext) : base(dbContext) { }

        public void ClearBonuses(int parentId, BonusType type)
        {
            IQueryable<BaseBonusJoin> set; 
            switch (type)
            {
                case BonusType.Weapon:
                    set = DbContext.WeaponBonuses.Where(x => x.WeaponId == parentId);
                    break;
                case BonusType.Branch:
                    set = DbContext.BranchBonuses.Where(x => x.BranchId == parentId);
                    break;
                case BonusType.Race:
                    set = DbContext.RaceBonuses.Where(x => x.RaceId == parentId);
                    break;
                default:
                    return;
            }

            foreach (var entity in set)
                DbContext.Entry(entity).State = EntityState.Deleted;

            DbContext.SaveChanges();
        }

        public void BatchInsertBonuses(IQueryable<BaseBonusJoin> bonuses)
        {
            foreach (var entity in bonuses) 
                DbContext.Entry(entity).State = EntityState.Added;

            DbContext.SaveChanges();
        }
    }
}
