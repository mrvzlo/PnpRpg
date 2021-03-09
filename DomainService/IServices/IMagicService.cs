using System.Linq;
using Pnprpg.DomainService.Models;

namespace Pnprpg.DomainService.IServices
{
    public interface IMagicService : IEditService<SpellEditModel>
    {
        IQueryable<MagicSchoolModel> GetAllSchools();
        IQueryable<SpellViewModel> GetAll(int? school = null);
        int Save(SpellEditModel model);
        SpellViewModel GetRandomSpell();
    }
}
