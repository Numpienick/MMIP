using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Entities
{
    public class Phase : BaseEntity
    {
        public Text Name { get; set; }
        public int Order { get; set; }
        public Text[] Texts { get; set; }
        public Field[] RequiredeFields { get; set; }
        public UserGroup[] VisibleTo { get; set; }
    }
}
