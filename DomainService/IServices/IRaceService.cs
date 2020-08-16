using System.Collections.Generic;
using Pnprpg.DomainService.Models;

namespace Pnprpg.DomainService.IServices
{
    public interface IRaceService
    {
        List<RaceModel> GetAll();
        ServiceResponse<HeroModel> AssignRace(HeroModel hero, int raceId);
    }
}
