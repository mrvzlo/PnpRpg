using System;
using System.Collections.Generic;
using System.Linq;
namespace Pnprpg.DomainService.Models.Common
{
    public abstract class AssignableWithEffects : Assignable
    {
        public List<EffectDescModel> Effects { get; set; }
    }
}
