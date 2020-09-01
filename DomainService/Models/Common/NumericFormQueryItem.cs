using System.Collections.Generic;

namespace Pnprpg.DomainService.Models
{
    public class NumericFormQueryItem : FormQueryItem
    {
        public int Value;

        public NumericFormQueryItem(List<Selectable> list, int position = 0, object selected = null, int value = 0) : base(list, position, selected)
        {
            Value = value;
        }
    }
}
