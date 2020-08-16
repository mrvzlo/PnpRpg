using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pnprpg.DomainService.Models
{
    public class PerkEditModel
    {
        public int Id { get; set; }
        public List<RequirementCommonModel> RequirementsForPerks { get; set; }
        [Required]
        public int Level { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int BranchId { get; set; }
        [Required]
        public int Max { get; set; }

        public PerkEditModel()
        {
            Max = 1;
        }
    }
}