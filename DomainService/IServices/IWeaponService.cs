using Pnprpg.DomainService.Models;

namespace Pnprpg.DomainService.IServices
{
    public interface IWeaponService : IViewService<WeaponViewModel>, IEditService<WeaponEditModel>
    {
        int Save(WeaponEditModel model);
    }
}
