using Pnprpg.DomainService.Entities;
using Pnprpg.DomainService.IRepositories;

namespace Pnprpg.Infrastructure.Repositories
{
    public class MajorRepository : BaseRepository<Major>, IMajorRepository
    {
        protected MajorRepository(AppDbContext context) : base(context)
        {
        }
    }
}
