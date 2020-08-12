using Pnprpg.DomainService.Entities;
using Pnprpg.DomainService.IRepositories;

namespace Pnprpg.Infrastructure.Repositories
{
    public class AlchemySymbolRepository : BaseRepository<AlchemySymbol>, IAlchemySymbolRepository
    {
        public AlchemySymbolRepository(AppDbContext dbContext) : base(dbContext) { }
    }
}
