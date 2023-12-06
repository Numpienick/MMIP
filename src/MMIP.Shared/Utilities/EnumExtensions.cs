using System.ComponentModel;
using System.Reflection;

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

        public static string GetCommentTypePropertyValue(this Enum value, string propertyName)
        {
            Type type = value.GetType();
            string name = Enum.GetName(type, value);

            try
            {
                FieldInfo field = type.GetField(name);
                if (field != null)
                {
                    if (
                        Attribute.GetCustomAttribute(field, typeof(CommentTypeAttribute))
                        is CommentTypeAttribute attribute
                    )
                    {
                        var propertyInfo = typeof(CommentTypeAttribute).GetProperty(propertyName);
                        return propertyInfo.GetValue(attribute, null).ToString();
                    }
                }
            }
            catch (ArgumentNullException)
            {
                throw;
            }

            return name;
        }
    }
}
