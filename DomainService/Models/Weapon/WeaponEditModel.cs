using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pnprpg.DomainService.Models
{
    public class WeaponEditModel : IBaseEditModel
    {
        public int Id { get; set; }
        public int Level { get; set; }
        public int Weight { get; set; }
        public int SkillId { get; set; }
        [Required]
        public string Name { get; set; }

        public List<BonusViewModel> Bonuses { get; set; }
    }
}