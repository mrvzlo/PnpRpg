using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Pnprpg.DomainService.Models
{
    public class SpellEditModel : IBaseEditModel
    {
        public int Id { get; set; }
        [DisplayName("Школа магии")]
        public int MagicSchoolId { get; set; }
        [DisplayName("Уровень заклинания")]
        public int Level { get; set; }
        [Required, DisplayName("Название")]
        public string Name { get; set; }
        [Required, DisplayName("Цена")]
        public string Cost { get; set; }
        [Required, DisplayName("Эффект")]
        public string Effect { get; set; }
    }
}
