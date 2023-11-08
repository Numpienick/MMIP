using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Entities
{
    public class Text : BaseEntity
    {
        public string Value { get; set; }
        public Guid ParentId { get; set; }
        public string LanguageIso { get; set; }
    }
}
