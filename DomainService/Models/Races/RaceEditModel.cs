using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Pnprpg.DomainService.Models
{
    public class RaceEditModel : IBaseEditModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [AllowHtml, Required]
        public string Description { get; set; }
        public List<int> Bonuses { get; set; }
        public List<AbilityAssignModel> Abilities { get; set; }
    }
}