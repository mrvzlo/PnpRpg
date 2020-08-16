using System.Data.Entity;
using System.Linq;
using Pnprpg.DomainService.Entities;
using Pnprpg.DomainService.IRepositories;

namespace Pnprpg.Infrastructure.Repositories
{
    public class PerkRepository : BaseRepository<Perk>, IPerkRepository
    {
        public PerkRepository(AppDbContext dbContext) : base(dbContext) { }

        public override IQueryable<Perk> Select() => 
            base.Select().Include(x => x.RequirementsForPerks).Include(x => x.Branch);

        public override Perk Get(int id) => 
            Select().FirstOrDefault(x => x.Id == id);
    }
}
