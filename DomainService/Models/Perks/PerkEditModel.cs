using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Pnprpg.DomainService.Enums;

namespace Pnprpg.DomainService.Models
{
    public class PerkEditModel : BaseSettingPartEditModel
    {
        [Required, DisplayName("Уровень")]
        public int Level { get; set; }
        [Required, DisplayName("Название")]
        public string Name { get; set; }
        [Required, DisplayName("Описание")]
        public string Description { get; set; }
        [Required, DisplayName("Класс")]
        public int BranchId { get; set; }
        [Required, DisplayName("Ранги")]
        public int Max { get; set; }

        public PerkEditModel()
        {
            Max = 1;
        }
    }
}