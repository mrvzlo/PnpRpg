using Pnprpg.DomainService.Models;

namespace Pnprpg.DomainService.IServices
{
    public interface IWeaponService : IViewService<WeaponViewModel>, IEditService<WeaponEditModel>
    {
        void Save(WeaponEditModel model);
    }
}
