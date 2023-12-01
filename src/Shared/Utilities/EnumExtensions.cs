﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Utilities
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

        public static string GetReactionTypePropertyValue(this Enum value, string propertyName)
        {
            Type type = value.GetType();
            string name = Enum.GetName(type, value);

            try
            {
                FieldInfo field = type.GetField(name);
                if (field != null)
                {
                    if (
                        Attribute.GetCustomAttribute(field, typeof(ReactionTypeAttribute))
                        is ReactionTypeAttribute attribute
                    )
                    {
                        var propertyInfo = typeof(ReactionTypeAttribute).GetProperty(propertyName);
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
