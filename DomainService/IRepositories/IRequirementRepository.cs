using Pnprpg.DomainService.Entities;

namespace Pnprpg.DomainService.IRepositories
{
    public interface IRequirementRepository : IBaseRepository<RequirementForPerk>
    {
        void ClearPerkRequirements(int perkId);
    }
}
