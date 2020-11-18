using System.Collections.Generic;

namespace Pnprpg.DomainService.Models
{
    public class FormQueryItem : List<Selectable>
    {
        public int Position { get; set; }

        public FormQueryItem(List<Selectable> list, int position = 0) : base(list)
        {
            Position = position;
        }
    }
}
