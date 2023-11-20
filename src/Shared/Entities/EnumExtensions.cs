﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Entities
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
