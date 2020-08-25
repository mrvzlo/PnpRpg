using System.Collections.Generic;

namespace Pnprpg.DomainService.Models
{
    public class FormQueryItem : SelectableList
    {
        public int Position { get; set; }

        public FormQueryItem(List<Selectable> list, int position = 0, object selected = null) : base(list, selected)
        {
            Position = position;
        }
    }
}
