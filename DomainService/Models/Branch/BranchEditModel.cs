using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Pnprpg.DomainService.Models
{
    public class BranchEditModel : IBaseEditModel
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(6)]
        public string Color { get; set; }
        [AllowHtml]
        public string Description { get; set; }
        [Required]
        public string ShortDescription { get; set; }

        public ICollection<int> Bonuses { get; set; }
    }
}