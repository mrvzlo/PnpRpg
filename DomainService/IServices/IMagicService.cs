using System.Linq;
using Pnprpg.DomainService.Models.Magic;

namespace Pnprpg.DomainService.IServices
{
    public interface IMagicService
    {
        IQueryable<MagicSchoolGroupModel> GetAllGroups();

        SpellModel GetRandomSpell();
    }
}
