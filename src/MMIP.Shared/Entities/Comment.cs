using System.ComponentModel.DataAnnotations;

namespace MMIP.Shared.Entities
{
    public class Comment : BaseEntity
    {
        [Required(ErrorMessage = "Een tekstuele reactie is vereist.")]
        [StringLength(1000, ErrorMessage = "Maximale omschrijving is 1000 karakters.")]
        public string Text { get; set; } = null!;

        public Guid ChallengeId { get; set; }
        public bool Concluded { get; set; }
        public Guid CreatorId { get; set; }
        public Guid CommentTypeId { get; set; }
    }
}
