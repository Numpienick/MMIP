using System.ComponentModel.DataAnnotations;
using Shared.Enums;

namespace Shared.Entities
{
    public class Challenge : BaseEntity
    {
        //TODO: Make it work with Text instead of string
        [Required(ErrorMessage = "Challenge titel is vereist.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Omschrijving is vereist.")]
        [StringLength(100000, ErrorMessage = "Maximale omschrijving is 100.000 karakters.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Korte omschrijving is vereist.")]
        [StringLength(1000, ErrorMessage = "Maximale omschrijving is 1000 karakters.")]
        public string ShortDescription { get; set; }

        public string? BannerImagePath { get; set; }

        [Required(ErrorMessage = "Challenge heeft deadline nodig.")]
        public DateTime Deadline { get; set; }

        public DateTimeOffset StartDate { get; set; }
        public string? FinalReport { get; set; }

        //TODO: add organization to creating challenges
        public Organization Organization { get; set; }
        public Guid OrganizationId { get; }

        [Required(ErrorMessage = "Zichtbaarheid moet gedefinieerd worden.")]
        public Visibility ChallengeVisibility { get; set; }

        public string[] Tags =>
            _tags.Any() ? _tags.Select(t => t.Value).ToArray() : Array.Empty<string>();
        public IEnumerable<Phase> Phases { get; set; } = new List<Phase>();

        public Guid CurrentPhaseId { get; set; }

        private IEnumerable<Tag> _tags { get; set; }
    }
}
