using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Utilities
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public class ReactionTypeAttribute : Attribute
    {
        public string Name { get; }
        public string IconPath { get; }
        public string Description { get; }

        public ReactionTypeAttribute(string iconPath, string name, string description)
        {
            IconPath = iconPath;
            Name = name;
            Description = description;
        }
    }
}
