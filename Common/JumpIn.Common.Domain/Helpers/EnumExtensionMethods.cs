using System;
using System.ComponentModel;
using System.Reflection;

namespace JumpIn.Common.Domain.Helpers
{
    public static class EnumExtensionMethods
    {
        public static string GetEnumDescription(this Enum value)
        {
            if (value is null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            FieldInfo fieldInfo = value.GetType().GetField(value.ToString());

            if (fieldInfo is null)
            {
                return null;
            }

            var attribute = (DescriptionAttribute)fieldInfo.GetCustomAttribute(typeof(DescriptionAttribute));
            return attribute.Description;
        }
    }
}
