using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Entities
{
    public class Challenge : BaseEntity
    {
        [Required(ErrorMessage = "Required")]
        public Text Title { get; set; }

        [Required(ErrorMessage = "Required")]
        [StringLength(8, ErrorMessage = "Description length needs to be more than 8.")]
        public Text Description { get; set; }
        public DateTimeOffset Deadline { get; set; }
        public Text FinalReport { get; set; }
    }
}
