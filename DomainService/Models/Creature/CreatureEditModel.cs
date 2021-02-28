using System.ComponentModel.DataAnnotations;

namespace Pnprpg.DomainService.Models
{
    public class CreatureEditModel : IBaseEditModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Level { get; set; }
        [Required]
        public string Group { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
