using System.Collections.Generic;

namespace Pnprpg.DomainService.Entities
{
    public class MagicSchoolGroup : BaseEntity<int>
    {
        public string Special { get; set; }
        public string Element { get; set; }
        public string Color { get; set; }

        public virtual ICollection<MagicSchool> Schools { get; set; }
    }
}