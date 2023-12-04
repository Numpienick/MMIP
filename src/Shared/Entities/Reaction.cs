using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Enums;

namespace Shared.Entities
{
    public class Reaction : BaseEntity
    {
        [Required(ErrorMessage = "Een tekstuele reactie is vereist.")]
        [StringLength(1000, ErrorMessage = "Maximale omschrijving is 1000 karakters.")]
        public string Text { get; set; }
        public bool Concluded { get; set; }
        public ReactionType ReactionType { get; set; }
    }
}
