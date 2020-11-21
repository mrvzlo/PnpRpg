using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Pnprpg.DomainService.IServices;

namespace Pnprpg.WebCore.Pages.Editor.Spells
{
    public class IndexModel : EditorPage
    {
        private readonly IMagicService _magicService;

        public IndexModel(IMagicService magicService)
        {
            _magicService = magicService;
        }

        public void OnGet() { }

        public PartialViewResult OnGetGrid()
        {
            var list = _magicService.GetAll().OrderBy(x => x.MagicSchoolId);
            return Partial(SitePages.EditorSpells_Grid, list);
        }

        public ActionResult OnPostDelete(int modelId)
        {
            _magicService.Delete(modelId);
            return RedirectToPage(SitePages.EditorSpellsIndex);
        }
    }
}
