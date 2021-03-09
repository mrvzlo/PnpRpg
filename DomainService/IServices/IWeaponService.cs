using System.Linq;
using Pnprpg.DomainService.Enums;
using Pnprpg.DomainService.Models;

namespace Pnprpg.DomainService.IServices
{
    public interface IWeaponService : IEditService<WeaponEditModel>
    {
        IQueryable<WeaponViewModel> GetAll(MajorType major, int? filter = null);
        int Save(WeaponEditModel model);
    }
}
