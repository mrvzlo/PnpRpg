using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Pnprpg.DomainService.IServices;

namespace Pnprpg.WebCore.Pages.Editor.Weapons
{
    public class IndexModel : EditorPage
    {
        private readonly IWeaponService _weaponService;

        public IndexModel(IWeaponService weaponService, IMajorService majorService) : base(majorService)
        {
            _weaponService = weaponService;
        }

        public void OnGet() { }

        public PartialViewResult OnGetGrid()
        {
            var list = _weaponService.GetAll().OrderBy(x => x.Level);
            return Partial(SitePages.EditorWeapons_Grid, list);
        }

        public ActionResult OnPostDelete(int modelId)
        {
            _weaponService.Delete(modelId);
            return RedirectToPage(SitePages.EditorWeaponsIndex);
        }
    }
}
