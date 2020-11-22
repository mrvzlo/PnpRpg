using System.ComponentModel.DataAnnotations;

namespace Pnprpg.DomainService.Models
{
    public class SpellEditModel : IBaseEditModel
    {
        public int Id { get; set; }
        public int MagicSchoolId { get; set; }
        public int Level { get; set; }
        public int Damage { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Cost { get; set; }
        [Required]
        public string Effect { get; set; }
    }
}
