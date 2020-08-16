using System.Collections.Generic;

namespace Pnprpg.DomainService.Models
{
    public class MagicSchoolModel
    {
        public int Id { get; set; }
        public string Desctiption { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public int GroupId { get; set; }

        public List<SpellModel> Spells { get; set; }
    }
}