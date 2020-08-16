using System.Collections.Generic;
using Pnprpg.DomainService.Models;

namespace Pnprpg.DomainService.IServices
{
    public interface ITraitService
    {
        List<TraitModel> GetAll();
        TraitGroup GetForHero(HeroModel hero);
        ServiceResponse<HeroModel> AssignTraitToHero(HeroModel hero, int traitId);
        ServiceResponse<HeroModel> ResetTraitsForHero(HeroModel hero);
    }
}
