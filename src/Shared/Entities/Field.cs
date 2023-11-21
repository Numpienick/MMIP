using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Entities
{
    public class Field : BaseEntity
    {
        private string[] _requiredFields;

        public string[] RequiredFields
        {
            get => _requiredFields;
            set => _requiredFields = value;
        }
    }
}
