namespace Pnprpg.DomainService.Models.Common
{
    public class Selectable
    {
        public string Text { get; set; }
        public string Value { get; set; }

        public Selectable(){}

        public Selectable(dynamic value, dynamic text)
        {
            Text = text.ToString();
            Value = value.ToString();
        }
    }
}
