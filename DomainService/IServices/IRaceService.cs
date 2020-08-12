using System.Collections.Generic;
using Pnprpg.DomainService.Models;
using Pnprpg.DomainService.Models.Processing;
using Pnprpg.DomainService.Models.Races;

namespace Pnprpg.DomainService.IServices
{
    public interface IRaceService
    {
        List<RaceModel> GetAll();
        ServiceResponse<HeroModel> AssignRace(HeroModel hero, int raceId);
    }
}
