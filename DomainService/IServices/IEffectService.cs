using Pnprpg.DomainService.Enums;
using Pnprpg.DomainService.Models;

namespace Pnprpg.DomainService.IServices
{
    public interface IEffectService
    {
        RaceViewModel AssignEffects(RaceViewModel target);
        TraitModel AssignEffects(TraitModel target);
        void ClearEffects(int parentId, AssignableType parentType);
    }
}
