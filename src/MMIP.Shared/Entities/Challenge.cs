using MMIP.Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace MMIP.Shared.Entities
{
    public class Challenge : BaseEntity
    {
        public Challenge()
        {
            Tags = new();
        }

        //TODO: Make it work with Text instead of string
        [Required(ErrorMessage = "Challenge titel is vereist.")]
        public string Title { get; set; } = null!;

        [Required(ErrorMessage = "Omschrijving is vereist.")]
        [StringLength(100000, ErrorMessage = "Maximale omschrijving is 100.000 karakters.")]
        public string Description { get; set; } = null!;

        [Required(ErrorMessage = "Korte omschrijving is vereist.")]
        [StringLength(150, ErrorMessage = "Maximale omschrijving is 150 karakters.")]
        public string ShortDescription { get; set; } = null!;

        [Required(ErrorMessage = "Challenge heeft deadline nodig.")]
        public DateTime? Deadline { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public string? FinalReport { get; set; }
        public List<Tag> Tags { get; set; } = new();
        public Organization? Organization { get; set; } //TODO: add organization to creating challenges

        [Required(ErrorMessage = "Zichtbaarheid moet gedefinieerd worden.")]
        public Visibility ChallengeVisibility { get; set; } = Visibility.VisibleToEmployees;

        public string? BannerImagePath { get; set; }
        public Guid OrganizationId { get; set; } // TODO: add organization to creating challenges
        public Guid CurrentPhaseId { get; set; }
        public List<Phase> Phases { get; set; } = new();
    }
}
