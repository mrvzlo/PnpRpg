using System.Web.Mvc;

namespace Pnprpg.DomainService.Models
{
    public class EffectSelectModel : SelectListPosition
    {
        public EffectDescModel Selected { get; set; }
        public SelectList EffectTypes { get; set; }
    }
}