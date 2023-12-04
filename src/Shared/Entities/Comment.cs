using System.ComponentModel.DataAnnotations;
using Shared.Enums;

namespace Shared.Entities
{
    public class Comment : BaseEntity
    {
        [Required(ErrorMessage = "Een tekstuele reactie is vereist.")]
        [StringLength(1000, ErrorMessage = "Maximale omschrijving is 1000 karakters.")]
        public string Text { get; set; }
        public bool Concluded { get; set; }
        public CommentType CommentType { get; set; }
    }
}
