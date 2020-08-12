using System.ComponentModel.DataAnnotations.Schema;
using Pnprpg.DomainService.Enums;

namespace Pnprpg.DomainService.Entities
{
    [Table("RequirementsForPerks")]
    public class RequirementForPerk : BaseEntity<int>
    {
        public RequirementType Type { get; set; }
        public int Value { get; set; }
        public int? AbilityId { get; set; }
        public int PerkId { get; set; }

        public virtual Ability Ability { get; set; }
        public virtual Perk Perk{ get; set; }
    }
}