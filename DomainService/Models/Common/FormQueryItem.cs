using System.Collections.Generic;

namespace Pnprpg.DomainService.Models
{
    public class FormQueryItem : List<Selectable>
    {
        public int Position { get; set; }

        public FormQueryItem(List<Selectable> list, int position = 0, int selected = 0) : base(list)
        {
            Position = position;
            foreach (var item in this) 
                item.Selected = item.Value == selected.ToString();
        }
    }
}
