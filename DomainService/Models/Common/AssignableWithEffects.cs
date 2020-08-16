using System.Collections.Generic;

namespace Pnprpg.DomainService.Models
{
    public abstract class AssignableWithEffects : Assignable
    {
        public List<EffectDescModel> Effects { get; set; }
    }
}
