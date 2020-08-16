using System.Linq;
using Pnprpg.DomainService.Models;

namespace Pnprpg.DomainService.IServices
{
    public interface IMagicService
    {
        IQueryable<MagicSchoolModel> GetAll();

        SpellModel GetRandomSpell();
    }
}
