using System.Web.Mvc;

namespace Pnprpg.DomainService.Models
{
    public class RequirementSelectModel : SelectListPosition
    {
        public RequirementCommonModel Selected { get; set; }
        public SelectList Requirements { get; set; }
    }
}