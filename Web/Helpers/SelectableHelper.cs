using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using Pnprpg.DomainService.Models;

namespace Pnprpg.WebCore.Helpers
{
    public static class SelectableHelper
    {
        public static List<SelectListItem> GetSelectList(List<Selectable> selectable) => selectable.Select(GetFromSelectable).ToList();

        private static SelectListItem GetFromSelectable(Selectable selectable) =>
            new SelectListItem
            {
                Text = selectable.Text,
                Value = selectable.Value,
                Selected = selectable.Selected
            };
    }
}