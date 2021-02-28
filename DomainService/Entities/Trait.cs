using System.Collections.Generic;

namespace Pnprpg.DomainService.Entities
{
    public class Trait : BaseSettingPart
    {
        public string Name { get; set; }

        public virtual ICollection<TraitEffect> Effects{ get; set; }
    }
}