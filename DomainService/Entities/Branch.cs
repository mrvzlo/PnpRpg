using System.Collections.Generic;

namespace Pnprpg.DomainService.Entities
{
    public class Branch : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Color { get; set; }
    }
}
