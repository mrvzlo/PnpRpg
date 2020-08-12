using System;
using System.Collections.Generic;

namespace Pnprpg.DomainService.Entities
{
    public class Room : BaseEntity<int>
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }

        public virtual ICollection<AppUser> Players { get; set; }
    }
}