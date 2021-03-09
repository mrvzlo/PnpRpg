using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Pnprpg.DomainService.Enums;
using Pnprpg.DomainService.IServices;
using Pnprpg.WebCore.Helpers;

namespace Pnprpg.WebCore.Pages.Major.Editor.Weapons
{
    public class IndexModel : EditorPage
    {
        private readonly IWeaponService _weaponService;

        public IndexModel(IWeaponService weaponService, IMajorService majorService) : base(majorService)
        {
            _weaponService = weaponService;
        }

        public void OnGet() { }

        public PartialViewResult OnGetGrid(MajorType major)
        {
            var list = _weaponService.GetAll(major).OrderBy(x => x.Level);
            return Partial(SitePages.MajorEditorWeapons_Grid, list);
        }

        public ActionResult OnPostDelete(int modelId)
        {
            _weaponService.Delete(modelId);
            return CustomRedirect(SitePages.MajorEditorWeaponsIndex);
        }
    }
}
