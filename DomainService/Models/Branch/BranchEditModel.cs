using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Pnprpg.DomainService.Enums;

namespace Pnprpg.DomainService.Models
{
    public class BranchEditModel : BaseSettingPartEditModel
    {
        [StringLength(50), Required, DisplayName("Название")]
        public string Name { get; set; }
        [StringLength(6), DisplayName("Цвет")]
        public string Color { get; set; }
        [AllowHtml, Required, DisplayName("Описание")]
        public string Description { get; set; }
        [Required, DisplayName("Краткое описание")]
        public string ShortDescription { get; set; }

        public ICollection<int> Bonuses { get; set; }
    }
}