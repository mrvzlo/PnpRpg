using System.Collections.Generic;

namespace Pnprpg.DomainService.Models
{
    public class NumericFormQueryItem : FormQueryItem
    {
        public int Value { get; set; }

        public NumericFormQueryItem(List<Selectable> list, int position = 0, string value = null) 
            : base(list, position)
        {
            Value = int.Parse(value ?? "0");
        }
    }
}
