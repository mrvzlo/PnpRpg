using System.ComponentModel.DataAnnotations;

namespace Pnprpg.DomainService.Models
{
    public class PerkEditModel : IBaseEditModel
    {
        public int Id { get; set; }
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