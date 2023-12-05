using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Entities
{
    public class UserGroup : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        [NotMapped]
        public string[] Permissions => _permissions.Split(';', StringSplitOptions.TrimEntries);

        private string _permissions { get; set; }
    }
}
