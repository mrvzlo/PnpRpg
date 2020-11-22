using System.Collections.Generic;

namespace Pnprpg.DomainService.Models
{
    public class NumericFormQueryItem : FormQueryItem
    {
        public int Value { get; set; }

        public NumericFormQueryItem(List<Selectable> list, int position = 0, int selected = 0, int value = 0) 
            : base(list, position, selected)
        {
            Value = value;
        }
    }
}
