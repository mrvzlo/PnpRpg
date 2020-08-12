using Pnprpg.DomainService.Models.Races;
using Pnprpg.DomainService.Models.Traits;

namespace Pnprpg.DomainService.IServices
{
    public interface IEffectService
    {
        RaceModel AssignEffects(RaceModel target);
        TraitModel AssignEffects(TraitModel target);
    }
}
