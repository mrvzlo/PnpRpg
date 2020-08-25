using System.Collections.Generic;
using System.Web.Mvc;

namespace Pnprpg.DomainService.Models
{
    public class SelectableList
    {
        public object Selected { get; set; }
        public List<Selectable> List { get; set; }
        
        public SelectableList(List<Selectable> list, object selected = null)
        {
            List = list;
            Selected = selected;
        }

        public SelectList GetSelectList() => 
            new SelectList(List, nameof(Selectable.Value), nameof(Selectable.Text), Selected);
    }
}