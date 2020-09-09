using System.Data.Entity;
using System.Linq;
using Pnprpg.DomainService.Entities;
using Pnprpg.DomainService.IRepositories;

namespace Pnprpg.Infrastructure.Repositories
{
    public class BranchRepository : BaseRepository<Branch>, IBranchRepository
    {
        public BranchRepository(AppDbContext dbContext) : base(dbContext) { }
        public override IQueryable<Branch> Select() => base.Select().Include(x => x.Bonuses);
    }
}
