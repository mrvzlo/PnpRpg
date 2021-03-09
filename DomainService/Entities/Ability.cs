using Pnprpg.DomainService.Enums;

namespace Pnprpg.DomainService.Entities
{
    public class Ability : BaseSettingPart
    {
        public AbilityType Type { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public string Description { get; set; }
        public string Influence { get; set; }
    }
}