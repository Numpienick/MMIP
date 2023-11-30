using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Entities
{
    public class Reaction : BaseEntity
    {
        public string Text { get; set; }
        public bool Concluded { get; set; }
        public ReactionType ReactionType { get; set; }
    }
}
