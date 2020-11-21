using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Pnprpg.DomainService.Enums;
using Pnprpg.DomainService.IServices;
using Pnprpg.DomainService.Models;

namespace Pnprpg.WebCore.Pages.Editor.Races
{
    public class EditModel : EditorPage
    {
        [BindProperty]
        public RaceEditModel Input { get; set; }
        public List<Selectable> Bonuses { get; set; }
        public List<Selectable> Abilities { get; set; }

        private readonly IRaceService _raceService;
        private readonly ICoreLogic _coreLogic;
        private readonly IAbilityService _abilityService;
        private readonly IBonusService _bonusService;

        public EditModel(IRaceService raceService, ICoreLogic coreLogic, IAbilityService abilityService, IBonusService bonusService)
        {
            _raceService = raceService;
            _coreLogic = coreLogic;
            _abilityService = abilityService;
            _bonusService = bonusService;
        }

        public void OnGet(int? id)
        {
            Prepare(id);
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                var newId = _raceService.Save(Input);
                if (Input.Id != newId)
                    return RedirectToPage(SitePages.EditorRacesEdit, new { id = newId });
            }

            Prepare(Input.Id);
            return Page();
        }

        private void Prepare(int? id)
        {
            Input = _raceService.GetForEdit(id);
            var abilities = _abilityService.GetAll<AbilityModel>();
            var bonuses = _bonusService.GetAll((int)BonusType.Race);
            Abilities = _coreLogic.ToSelectableList(abilities);
            Bonuses = _coreLogic.ToSelectableList(bonuses);
        }
    }
}
