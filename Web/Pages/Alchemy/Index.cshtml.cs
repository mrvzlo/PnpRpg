using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Pnprpg.DomainService.IServices;
using Pnprpg.DomainService.Models;

namespace Pnprpg.WebCore.Pages.Alchemy
{
    public class IndexModel : PageModel
    {
        public List<SelectListItem> Reagents { get; set; }
        public List<SelectListItem> Processes { get; set; }

        private readonly IAlchemyService _alchemyService;

        public IndexModel(IAlchemyService alchemyService)
        {
            _alchemyService = alchemyService;
        }

        public void OnGet()
        {
            Reagents = ToSelectList(_alchemyService.GetAllReagents().ToList());
            Processes = ToSelectList(_alchemyService.GetAllProcesses().ToList());
        }

        public PartialViewResult OnGetResult(ReactionModel reaction)
        {
            var potion = _alchemyService.GetPotionByReaction(reaction);
            return Partial(SitePages.Alchemy_Result, potion);
        }

        public PartialViewResult OnGetRandom()
        {
            var potion = _alchemyService.GetRandomPotion();
            return Partial(SitePages.Alchemy_Result, potion);
        }

        private List<SelectListItem> ToSelectList(List<AlchemySymbolModel> list)
        {
            return list.Select(x => new SelectListItem
            {
                Text = $"{x.Symbol} {x.Name}",
                Value = x.Value.ToString()
            }).ToList();
        }
    }
}
