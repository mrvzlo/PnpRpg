using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Pnprpg.DomainService.Enums;

namespace Pnprpg.DomainService.Models
{
    public class SkillEditModel : BaseSettingPartEditModel
    {
        [Required, DisplayName("Название")]
        public string Name { get; set; }
        [DisplayName("Сложность")]
        public int Difficulty { get; set; }
        [DisplayName("Атрибут")]
        public int? AbilityId { get; set; }
        [DisplayName("Класс")]
        public int? BranchId { get; set; }
        [DisplayName("Тип")]
        public SkillType Type { get; set; }
    }
}
