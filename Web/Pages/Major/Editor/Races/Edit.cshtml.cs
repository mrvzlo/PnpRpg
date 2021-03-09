using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Pnprpg.DomainService.Enums;
using Pnprpg.DomainService.IServices;
using Pnprpg.DomainService.Models;

namespace Pnprpg.WebCore.Pages.Major.Editor.Races
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

        public EditModel(IRaceService raceService, ICoreLogic coreLogic, IAbilityService abilityService, 
            IBonusService bonusService, IMajorService majorService) : base(majorService)
        {
            _raceService = raceService;
            _coreLogic = coreLogic;
            _abilityService = abilityService;
            _bonusService = bonusService;
        }

        public void OnGet(MajorType major, int? id)
        {
            Prepare(major, id);
        }

        public IActionResult OnPost(MajorType major)
        {
            if (ModelState.IsValid)
            {
                Input.MajorId = major;
                var newId = _raceService.Save(Input);
                if (Input.Id != newId)
                    return CustomRedirect(SitePages.MajorEditorRacesEdit, new { id = newId });
            }

            Prepare(major, Input.Id);
            return Page();
        }

        private void Prepare(MajorType major, int? id)
        {
            Input = _raceService.GetForEdit(id);
            var abilities = _abilityService.GetAll<AbilityModel>(major);
            var bonuses = _bonusService.GetAll(major, (int)BonusType.Race);
            Abilities = _coreLogic.ToSelectableList(abilities);
            Bonuses = _coreLogic.ToSelectableList(bonuses);
        }
    }
}
