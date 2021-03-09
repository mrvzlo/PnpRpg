using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Pnprpg.DomainService.IServices;
using Pnprpg.DomainService.Models;

namespace Pnprpg.WebCore.Pages.Major.Editor.Spells
{
    public class IndexModel : EditorPage
    {
        private readonly IMagicService _magicService;
        public List<MagicSchoolModel> Schools { get; set; }
        public int? Filtered { get; set; }

        public IndexModel(IMagicService magicService, IMajorService majorService) : base(majorService)
        {
            _magicService = magicService;
        }

        public void OnGet(int? id)
        {
            Filtered = id;
            Schools = _magicService.GetAllSchools().ToList();
        }

        public PartialViewResult OnGetGrid(int? filter)
        {
            var list = _magicService.GetAll(filter);
            return Partial(SitePages.MajorEditorSpells_Grid, list);
        }

        public ActionResult OnPostDelete(int modelId)
        {
            _magicService.Delete(modelId);
            return CustomRedirect(SitePages.MajorEditorSpellsIndex);
        }
    }
}
