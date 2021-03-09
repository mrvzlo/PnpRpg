using System.Data.Entity;
using System.Linq;
using Pnprpg.DomainService.Entities;
using Pnprpg.DomainService.Enums;
using Pnprpg.DomainService.IRepositories;

namespace Pnprpg.Infrastructure.Repositories
{
    public class TraitRepository : BaseSettingPartRepository<Trait>, ITraitRepository
    {
        public TraitRepository(AppDbContext dbContext) : base(dbContext) { }
        public override IQueryable<Trait> Select(MajorType major) => base.Select(major).Include(x => x.Effects);
    }
}
