using System.Collections.Generic;

namespace Pnprpg.DomainService.Models.Magic
{
    public class MagicSchoolGroupModel
    {
        public int Id { get; set; }
        public string Special { get; set; }
        public string Color { get; set; }
        public string Element { get; set; }
        public List<MagicSchoolInfoModel> Schools { get; set; }
    }
}