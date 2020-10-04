using System.Collections.Generic;

namespace Pnprpg.DomainService.Models
{
    public class MagicSchoolModel : IBaseViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public int GroupId { get; set; }

        public List<SpellViewModel> Spells { get; set; }
    }
}