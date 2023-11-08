using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Entities
{
    public class Challenge : BaseEntity
    {
        public Text Title { get; set; }
        public Text Description { get; set; }
        public DateTime Deadline { get; set; }
        public Text FinalReport { get; set; }
    }
}
