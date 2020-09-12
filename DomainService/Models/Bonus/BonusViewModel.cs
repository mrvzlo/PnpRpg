using System.Collections.Generic;
using Pnprpg.DomainService.Enums;

namespace Pnprpg.DomainService.Models
{
    public class BonusViewModel : IBaseViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public string Description { get; set; }
        public BonusType Type { get; set; }
        public int Usages { get; set; }
    }
}
