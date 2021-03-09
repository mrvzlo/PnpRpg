using System.Collections.Generic;
using System.ComponentModel;
using System.Web.Mvc;
using Pnprpg.DomainService.Enums;

namespace Pnprpg.DomainService.Models
{
    public class BonusEditModel : BaseSettingPartEditModel
    {
        [DisplayName("Название")]
        public string Name { get; set; }
        [AllowHtml]
        [DisplayName("Описание")]
        public string Description { get; set; }
        [DisplayName("Тип")]
        public BonusType Type { get; set; }
    }
}
