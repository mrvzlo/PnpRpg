using Pnprpg.DomainService.Entities;
using Pnprpg.DomainService.IRepositories;

namespace Pnprpg.Infrastructure.Repositories
{
    public class MagicSchoolRepository : BaseRepository<MagicSchool>, IMagicSchoolRepository
    {
        public MagicSchoolRepository(AppDbContext dbContext) : base(dbContext) { }
    }
}
