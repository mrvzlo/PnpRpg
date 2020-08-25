using Pnprpg.DomainService.Models;

namespace Pnprpg.DomainService.IServices
{
    public interface IBranchService : IViewService<BranchViewModel>, IEditService<BranchEditModel>
    {
        void Save(BranchEditModel model);
    }
}
