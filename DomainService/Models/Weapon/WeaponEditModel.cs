using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pnprpg.DomainService.Models
{
    public class WeaponEditModel : BaseSettingPartEditModel
    {
        public int Level { get; set; }
        public int Weight { get; set; }
        public int SkillId { get; set; }
        [Required]
        public string Name { get; set; }

        public List<int> Bonuses { get; set; }
    }
}