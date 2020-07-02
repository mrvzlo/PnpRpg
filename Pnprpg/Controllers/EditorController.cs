using Boot.Models;
using Boot.Enums;
using System.Linq;
using System.Web.Mvc;
using Boot.Helpers;
using System.Collections.Generic;
using Boot.Models.JsonModels;
using System.Xml.Linq;

namespace Boot.Controllers
{
    [Authorize(Roles = "Admin,Editor")]
    public class EditorController : BaseController
    {
        public ActionResult Perks()
        {
            return View(GetPerks());
        }

        public ActionResult EditPerk(int? id = null)
        {
            var perk = GetPerks().SingleOrDefault(x => x.id == id);
            var model = new PerkEditModel();

            if (perk != null)
            {
                model.Id = perk.id;
                model.Desc = perk.desc;
                model.Name = perk.name;
                model.Level = perk.requirements.Single(x => x.type == RequirementType.Level).value;
                model.Requirements = perk.requirements.Where(x => x.type != RequirementType.Level).ToList();
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPerk(PerkEditModel model)
        {
            var perks = GetPerks();
            Perk perk = null;
            if (model.Id != null)
                perk = perks.Single(x => x.id == model.Id);

            if (perk == null)
                perk = new Perk { id = perks.Max(x => x.id) + 1 };
            else
                perks.Remove(perk);

            var reqs = model.Requirements ?? new List<Requirement>();
            reqs.Add(new Requirement { type = RequirementType.Level, value = model.Level });

            perk.name = model.Name;
            perk.desc = model.Desc;
            perk.requirements = reqs;

            perks.Add(perk);

            SaveJsonToFile(perks, FileNames.Perks);

            return RedirectToAction("Perks");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePerk(int perkId)
        {
            var perks = GetPerks();
            perks.Remove(perks.FirstOrDefault(x => x.id == perkId));
            SaveJsonToFile(perks, FileNames.Perks);
            return RedirectToAction("Perks");
        }

        public JsonResult ReqirementSelectModel(int pos, int id = (int)RequirementType.Stat)
        {
            var model = GetReqirementSelectModel(pos, 0, null, id);
            var partial = this.RenderPartialViewToString("_RequirementSelect", model);
            return ReturnJson(partial, null);
        }

        public PartialViewResult ShowReqirementSelectModel(int pos, int value, string statId, int reqType = (int)RequirementType.Stat)
        {
            var model = GetReqirementSelectModel(pos, value, statId, reqType);
            return PartialView("_RequirementSelect", model);
        }

        private RequirementSelectModel GetReqirementSelectModel(int pos, int value, string statId, int reqType)
        {
            var requirements = new[] { RequirementType.Stat, RequirementType.Race, RequirementType.Perk };
            var reqSelectList = requirements.Select(x => new { Value = (int)x, Text = x.Description() });
            SelectList selectList = null;
            List<SelectListItem> values;

            switch ((RequirementType)reqType)
            {
                case RequirementType.Stat:
                    var stats = GetJsonFromFile<List<Stat>>(FileNames.Stats);
                    values = stats.Select(x => new SelectListItem { Value = x.Id, Text = x.Name }).ToList();
                    selectList = new SelectList(values, "Value", "Text", statId);
                    break;
                case RequirementType.Perk:
                    var perks = GetJsonFromFile<List<Perk>>(FileNames.Perks);
                    values = perks.Select(x => new SelectListItem { Value = x.id.ToString(), Text = x.name }).ToList();
                    selectList = new SelectList(values, "Value", "Text", value);
                    break;
                case RequirementType.Race:
                    var races = GetJsonFromFile<List<Race>>(FileNames.Races);
                    values = races.Select(x => new SelectListItem { Value = x.id.ToString(), Text = x.name }).ToList();
                    selectList = new SelectList(values, "Value", "Text", value);
                    break;
            }

            return new RequirementSelectModel
            {
                Pos = pos,
                Selected = new Requirement { statId = statId, type = (RequirementType)reqType, value = value },
                Requirements = new SelectList(reqSelectList, "Value", "Text", reqType),
                Values = selectList
            };
        }
    }
}