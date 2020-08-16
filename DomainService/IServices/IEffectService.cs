using Pnprpg.DomainService.Models;

namespace Pnprpg.DomainService.IServices
{
    public interface IEffectService
    {
        RaceModel AssignEffects(RaceModel target);
        TraitModel AssignEffects(TraitModel target);
    }
}
