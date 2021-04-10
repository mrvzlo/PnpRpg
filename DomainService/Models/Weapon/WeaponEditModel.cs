using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Pnprpg.DomainService.Models
{
    public class WeaponEditModel : BaseSettingPartEditModel
    {
        [DisplayName("Уровень")]
        public int Level { get; set; }
        [DisplayName("Вес")]
        public int Weight { get; set; }
        [DisplayName("Навык")]
        public int SkillId { get; set; }
        [DisplayName("Название"), Required]
        public string Name { get; set; }

        public List<int> Bonuses { get; set; }
    }
}