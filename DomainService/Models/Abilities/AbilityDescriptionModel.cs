using Pnprpg.DomainService.Enums;

namespace Pnprpg.DomainService.Models
{
    public class AbilityDescriptionModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public AbilityType Symbol { get; set; }
        public string Color { get; set; }
        public string Description { get; set; }
        public string Influence { get; set; }
    }
}