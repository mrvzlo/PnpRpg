using System.Xml.Serialization;

namespace Boot.Enums.Attributes
{
    public class TranslationAttribute : XmlEnumAttribute
    {
        public TranslationAttribute(string translation) => Value = translation;
        public string Value { get; set; }
    }
}