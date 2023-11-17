using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Entities
{
    public class Organization : BaseEntity, IProfile
    {
        public string Name { get; set; }
    }
}
