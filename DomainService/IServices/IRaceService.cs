using Pnprpg.DomainService.Models;

namespace Pnprpg.DomainService.IServices
{
    public interface IRaceService : IViewService<RaceViewModel>, IEditService<RaceEditModel>
    {
        ServiceResponse<HeroModel> AssignRace(HeroModel hero, int raceId);
        void Save(RaceEditModel model);
    }
}
