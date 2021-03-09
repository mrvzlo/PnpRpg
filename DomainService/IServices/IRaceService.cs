using System.Linq;
using Pnprpg.DomainService.Enums;
using Pnprpg.DomainService.Models;

namespace Pnprpg.DomainService.IServices
{
    public interface IRaceService : IEditService<RaceEditModel>
    {
        ServiceResponse<HeroModel> AssignRace(HeroModel hero, int raceId);
        int Save(RaceEditModel model);
        IQueryable<RaceViewModel> GetAll(MajorType major);
    }
}
