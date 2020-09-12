using System.Web.Mvc;
using Pnprpg.DomainService.Enums;

namespace Pnprpg.DomainService.Models
{
    public class BonusEditModel : IBaseEditModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        [AllowHtml]
        public string Description { get; set; }
        public BonusType Type { get; set; }
    }
}
