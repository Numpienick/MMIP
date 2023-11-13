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
        //TODO: Make it work with Text instead of string
        [Required(ErrorMessage = "Required")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Required")]
        [StringLength(1000, ErrorMessage = "Max description is 1000")]
        public string Description { get; set; }
        public DateTimeOffset Deadline { get; set; }
        public Text FinalReport { get; set; }
    }
}
