using System.Linq;
using Pnprpg.DomainService.Models;

namespace Pnprpg.DomainService.IServices
{
    public interface IMagicService : IViewService<SpellViewModel>, IEditService<SpellEditModel>
    {
        IQueryable<MagicSchoolModel> GetAllSchools();
        void Save(SpellEditModel model);
        SpellViewModel GetRandomSpell();
    }
}
