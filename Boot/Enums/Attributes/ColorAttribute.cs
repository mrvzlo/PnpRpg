using System.Xml.Serialization;

namespace Boot.Enums.Attributes
{
    public class ColorAttribute : XmlEnumAttribute
    {
        public ColorAttribute(string color) => Value = color;
        public string Value { get; set; }
    }
}