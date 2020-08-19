using System.Collections.Generic;
using Pnprpg.DomainService.Models;

namespace Pnprpg.DomainService.IServices
{
    public interface IRaceService
    {
        List<RaceViewModel> GetAll();
        RaceEditModel GetForEdit(int? id);
        ServiceResponse<HeroModel> AssignRace(HeroModel hero, int raceId);
        void Delete(int id);
        void Save(RaceEditModel model);
    }
}
