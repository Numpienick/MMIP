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
        private List<string> _tags;
        public List<string> Tags
        {
            get => _tags;
            set => _tags = value;
        }
        public string Description { get; set; }
        public string AvatarPath { get; set; }

        public string[] GetTags()
        {
            throw new NotImplementedException();
        }
    }
}
