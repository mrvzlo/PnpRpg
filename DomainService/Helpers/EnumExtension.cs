using System;
using System.ComponentModel;
using System.Linq;

namespace Pnprpg.DomainService.Helpers
{
    public static class EnumExtensions
    {
        public static string Description(this Enum value)
        {
            var attr = GetAttribute(value, typeof(DescriptionAttribute));
            return attr == null ? "" : ((DescriptionAttribute) attr).Description;
        }

        private static object GetAttribute(object value, Type t)
        {
            var fieldInfo = value?.GetType().GetField(value.ToString());
            return fieldInfo?.GetCustomAttributes(t, false).FirstOrDefault();
        }

        public static int GetEnumCount(Type t) => Enum.GetValues(t).Length;
    }
}