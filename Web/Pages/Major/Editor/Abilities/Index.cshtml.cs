using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Pnprpg.DomainService.Enums;
using Pnprpg.DomainService.IServices;
using Pnprpg.DomainService.Models;

namespace Pnprpg.WebCore.Pages.Major.Editor.Abilities
{
    public class IndexModel : EditorPage
    {
        private readonly IAbilityService _abilityService;

        public IndexModel(IAbilityService abilityService, IMajorService majorService) : base(majorService)
        {
            _abilityService = abilityService;
        }

        public void OnGet() { }

        public PartialViewResult OnGetGrid(MajorType major)
        {
            var list = _abilityService.GetAll<AbilityDescriptionModel>(major).OrderBy(x => x.Id);
            return Partial(SitePages.MajorEditorAbilities_Grid, list);
        }

        public ActionResult OnPostDelete(int modelId)
        {
            _abilityService.Delete(modelId);
            return CustomRedirect(SitePages.MajorEditorAbilitiesIndex);
        }
    }
}
