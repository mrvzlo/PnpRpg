using System.Collections.Generic;
using System.Web.Mvc;

namespace Pnprpg.DomainService.Models
{
    public class RaceEditModel : IBaseEditModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [AllowHtml]
        public string Description { get; set; }
        public List<int> Bonuses { get; set; }
    }
}