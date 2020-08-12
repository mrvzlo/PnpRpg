using System.Web.Mvc;
using Pnprpg.DomainService.Models.Common;

namespace Pnprpg.DomainService.Models.Requirements
{
    public class RequirementSelectModel : SelectListPosition
    {
        public RequirementCommonModel Selected { get; set; }
        public SelectList Requirements { get; set; }
    }
}