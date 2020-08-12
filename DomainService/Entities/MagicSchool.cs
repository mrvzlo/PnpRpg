using System.Collections.Generic;

namespace Pnprpg.DomainService.Entities
{
    public class MagicSchool : BaseEntity<int>
    {
        public string Description { get; set; }
        public string Name { get; set; }
        public int GroupId { get; set; }

        public virtual MagicSchoolGroup Group { get; set; }
        public virtual ICollection<Spell> Spells { get; set; }
    }
}