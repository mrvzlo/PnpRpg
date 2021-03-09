using System.Collections.Generic;
using System.Linq;
using Pnprpg.DomainService.Enums;
using Pnprpg.DomainService.Models;

namespace Pnprpg.DomainService.IServices
{
    public interface IBranchService : IEditService<BranchEditModel>
    {
        int Save(BranchEditModel model);
        List<BranchViewModel> GetAllWithPerks(MajorType major);
        IQueryable<BranchViewModel> GetAll(MajorType major);
        ServiceResponse<HeroModel> Assign(HeroModel hero, int branchId, int pos);
    }
}
