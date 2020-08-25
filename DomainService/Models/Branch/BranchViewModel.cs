using System.Collections.Generic;

namespace Pnprpg.DomainService.Models
{
    public class BranchViewModel : IBaseViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public string Description { get; set; }

        public ICollection<BonusViewModel> Bonuses { get; set; }
    }
}