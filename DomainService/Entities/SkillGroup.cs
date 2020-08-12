using System.Collections.Generic;

namespace Pnprpg.DomainService.Entities
{
    public class SkillGroup : BaseEntity<int>
    {
        public string Name { get; set; }

        public virtual ICollection<SkillInfo> Skills { get; set; }
    }
}