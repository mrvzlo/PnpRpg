using System.Linq;
using Pnprpg.DomainService.Entities;
using Pnprpg.DomainService.Enums;
using Pnprpg.DomainService.Models;

namespace Pnprpg.DomainService.IServices
{
    public interface IBonusService : IEditService<BonusEditModel>, IViewService<BonusViewModel>
    {
        void Save(BonusEditModel model);
        void BatchSave(IQueryable<BaseBonusJoin> list, int parentId, BonusType parentType);
        void BatchClear(int parentId, BonusType type);
    }
}
