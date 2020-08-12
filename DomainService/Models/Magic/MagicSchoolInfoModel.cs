using System.Collections.Generic;

namespace Pnprpg.DomainService.Models.Magic
{
    public class MagicSchoolInfoModel
    {
        public int Id { get; set; }
        public string Desctiption { get; set; }
        public string Name { get; set; }
        public int GroupId { get; set; }

        public MagicSchoolGroupModel Group { get; set; }
        public List<SpellModel> Spells { get; set; }
    }
}