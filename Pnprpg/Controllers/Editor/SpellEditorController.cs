using System.Web.Mvc;
using Pnprpg.DomainService.IServices;
using Pnprpg.DomainService.Models;

namespace Pnprpg.Web.Controllers
{
    public class SpellEditorController : BaseEditorController
    {
        private readonly IMagicService _magicService;
        private readonly ICoreLogic _coreLogic;

        public SpellEditorController(IMagicService magicService, ICoreLogic coreLogic)
        {
            _magicService = magicService;
            _coreLogic = coreLogic;
        }

        public ActionResult Spells()
        {
            var schools = _magicService.GetAllSchools();
            return View(schools);
        }

        public ActionResult SpellsGrid(int? filter) => Grid(_magicService, nameof(SpellsGrid), filter);

        public ActionResult EditSpell(int? id = null)
        {
            var model = _magicService.GetForEdit(id);
            return Edit(model, PrepareSpellEditViewBags, nameof(EditSpell));
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult EditSpell(SpellEditModel model) =>
            Edit(() => _magicService.Save(model), PrepareSpellEditViewBags, model, nameof(EditSpell), nameof(Spells));

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult DeleteSpell(int modelId) => Delete(_magicService, modelId, nameof(Spells));

        private void PrepareSpellEditViewBags()
        {
            var schools = _magicService.GetAllSchools();
            ViewBag.Schools = _coreLogic.ToSelectableList(schools);
        }
    }
}