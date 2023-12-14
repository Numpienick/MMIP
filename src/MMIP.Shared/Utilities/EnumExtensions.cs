using System.ComponentModel;

namespace MMIP.Shared.Utilities
{
    public static class EnumExtensions
    {
        public static string GetDescriptionAttribute(this Enum enumValue)
        {
            var field = enumValue.GetType().GetField(enumValue.ToString());
            if (field == null)
                return enumValue.ToString();

            var attributes = field.GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (
                Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute))
                is DescriptionAttribute attribute
            )
            {
                return attribute.Description;
            }

            return enumValue.ToString();
        }
    }
}
