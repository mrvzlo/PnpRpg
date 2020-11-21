using Pnprpg.DomainService.Models;

namespace Pnprpg.DomainService.IServices
{
    public interface IRaceService : IViewService<RaceViewModel>, IEditService<RaceEditModel>
    {
        ServiceResponse<HeroModel> AssignRace(HeroModel hero, int raceId);
        int Save(RaceEditModel model);
    }
}
