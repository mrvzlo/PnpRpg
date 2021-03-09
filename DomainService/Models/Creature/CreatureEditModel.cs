using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Pnprpg.DomainService.Models
{
    public class CreatureEditModel : BaseSettingPartEditModel
    {
        [Required, DisplayName("Название")]
        public string Name { get; set; }
        [Required, DisplayName("Уровень")]
        public int Level { get; set; }
        [Required, DisplayName("Группа")]
        public string Group { get; set; }
        [Required, DisplayName("Описание")]
        public string Description { get; set; }
    }
}
