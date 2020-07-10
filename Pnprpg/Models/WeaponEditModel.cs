using System.ComponentModel.DataAnnotations;

namespace Boot.Models
{
    public class WeaponEditModel
    {
        public int? Id { get; set; }
        public int Level { get; set; }
        public int Weight { get; set; }
        public int SkillId { get; set; }
        [Required]
        public string Name { get; set; }
    }
}