using System.Linq;
using Pnprpg.DomainService.Models;

namespace Pnprpg.DomainService.IServices
{
    public interface IMajorService
    {
        IQueryable<MajorFullModel> GetAllActive();
        MajorShortModel GetShortModel(int id);
    }
}
