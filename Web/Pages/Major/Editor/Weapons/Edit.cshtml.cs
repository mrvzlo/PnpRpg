using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Pnprpg.DomainService.Enums;
using Pnprpg.DomainService.IServices;
using Pnprpg.DomainService.Models;

namespace Pnprpg.WebCore.Pages.Major.Editor.Weapons
{
    public class EditModel : EditorPage
    {
        [BindProperty]
        public WeaponEditModel Input { get; set; }
        public List<Selectable> Skills{ get; set; }
        public List<Selectable> Bonuses { get; set; }

        private readonly ICoreLogic _coreLogic;
        private readonly IWeaponService _weaponService;
        private readonly IBonusService _bonusService;
        private readonly ISkillService _skillService;

        public EditModel(IWeaponService weaponService, IBonusService bonusService, ISkillService skillService, 
            ICoreLogic coreLogic, IMajorService majorService) : base(majorService)
        {
            _weaponService = weaponService;
            _bonusService = bonusService;
            _skillService = skillService;
            _coreLogic = coreLogic;
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
                var newId = _weaponService.Save(Input);
                if (Input.Id != newId)
                    return CustomRedirect(SitePages.MajorEditorWeaponsEdit, new {id = newId});
            }

            Prepare(major, Input.Id);
            return Page();
        }

        private void Prepare(MajorType major, int? id)
        {
            Input = _weaponService.GetForEdit(id);
            var skills = _skillService.SelectSkills(major, SkillType.Weapon);
            var bonuses = _bonusService.GetAll(major, (int)BonusType.Weapon);
            Skills = _coreLogic.ToSelectableList(skills, Input.SkillId.ToString());
            Bonuses = _coreLogic.ToSelectableList(bonuses);
        }

    }
}
