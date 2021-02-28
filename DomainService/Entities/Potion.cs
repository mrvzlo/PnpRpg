using Pnprpg.DomainService.Enums;

namespace Pnprpg.DomainService.Entities
{
    public class Potion : BaseEntity
    {
        public string Name { get; set; }
        public PotionType PotionType { get; set; }
    }
}