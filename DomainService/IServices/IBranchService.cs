using System.Collections.Generic;
using Pnprpg.DomainService.Models;

namespace Pnprpg.DomainService.IServices
{
    public interface IBranchService : IViewService<BranchViewModel>, IEditService<BranchEditModel>
    {
        int Save(BranchEditModel model);
        List<BranchViewModel> GetAllWithPerks();
        ServiceResponse<HeroModel> Assign(HeroModel hero, int branchId, int pos);
    }
}
