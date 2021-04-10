using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Pnprpg.DomainService.Enums;

namespace Pnprpg.DomainService.Models
{
    public class RaceEditModel : IBaseEditModel
    {
        public int Id { get; set; }
        public MajorType MajorId { get; set; }
        [Required, DisplayName("Название")]
        public string Name { get; set; }
        [AllowHtml, Required, DisplayName("Описание")]
        public string Description { get; set; }
        public List<int> Bonuses { get; set; }
        public List<AbilityAssignModel> Abilities { get; set; }
    }
}