using System;
using System.ComponentModel;
using System.Linq;
using Boot.Enums.Attributes;

namespace Boot.Helpers
{
    public static class EnumExtensions
    {
        public static string Description(this Enum value)
        {
            var attr = GetAttribute(value, typeof(DescriptionAttribute));
            return attr == null ? "" : ((DescriptionAttribute) attr).Description;
        }

        public static string Color(this Enum value)
        {
            var attr = GetAttribute(value, typeof(ColorAttribute));
            return attr == null ? "" : ((ColorAttribute)attr).Value;
        }

        public static string Translation(this Enum value)
        {
            var attr = GetAttribute(value, typeof(TranslationAttribute));
            return attr == null ? "" : ((TranslationAttribute)attr).Value;
        }

        private static object GetAttribute(object value, Type t)
        {
            var fieldInfo = value?.GetType().GetField(value.ToString());
            return fieldInfo?.GetCustomAttributes(t, false).FirstOrDefault();
        }

        public static int GetEnumCount(Type t) => Enum.GetValues(t).Length;
    }
}