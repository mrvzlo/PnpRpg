using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Pnprpg.DomainService.IServices;

namespace Pnprpg.WebCore.Pages.Editor.Weaponry
{
    public class IndexModel : EditorPage
    {
        private readonly IWeaponService _weaponService;

        public IndexModel(IWeaponService weaponService)
        {
            _weaponService = weaponService;
        }

        public void OnGet() { }

        public PartialViewResult OnGetGrid()
        {
            var list = _weaponService.GetAll().OrderBy(x => x.Level);
            return Partial(SitePages.EditorWeaponry_Grid, list);
        }

        public void OnPostDelete(int modelId)
        {
            _weaponService.Delete(modelId);
        }
    }
}
