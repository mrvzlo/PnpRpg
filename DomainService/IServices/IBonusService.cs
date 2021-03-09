using System.Linq;
using Pnprpg.DomainService.Entities;
using Pnprpg.DomainService.Enums;
using Pnprpg.DomainService.Models;

namespace Pnprpg.DomainService.IServices
{
    public interface IBonusService : IEditService<BonusEditModel>
    {
        int Save(BonusEditModel model);
        void BatchSave(IQueryable<BaseBonusJoin> list, int parentId, BonusType parentType);
        void BatchClear(int parentId, BonusType type);
        IQueryable<BonusViewModel> GetAll(MajorType major, int? filter = null);
    }
}
