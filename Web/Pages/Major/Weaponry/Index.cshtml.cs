using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Pnprpg.DomainService.Enums;
using Pnprpg.DomainService.IServices;
using Pnprpg.DomainService.Models;

namespace Pnprpg.WebCore.Pages.Major.Weaponry
{
    public class IndexModel : PageModel
    {
        public IQueryable<WeaponViewModel> Weapons { get; set; }

        private readonly IWeaponService _weaponService;

        public IndexModel(IWeaponService weaponService)
        {
            _weaponService = weaponService;
        }

        public void OnGet(MajorType major)
        {
            Weapons = _weaponService.GetAll(major);
        }
    }
}
