using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Enums;

namespace Shared.Entities
{
    public class Challenge : BaseEntity
    {
        //TODO: Make it work with Text instead of string
        [Required(ErrorMessage = "Challenge titel is vereist.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Omschrijving is vereist.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Korte omschrijving is vereist.")]
        [StringLength(1000, ErrorMessage = "Maximale omschrijving is 1000 karakters.")]
        public string ShortDescription { get; set; }
        public string? BannerImagePath { get; set; }

        [Required(ErrorMessage = "Challenge heeft deadline nodig.")]
        public DateTime? Deadline { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public string? FinalReport { get; set; }
        public string[]? Tags { get; set; } //TODO: add tags to creating challenges
        public Organization? Organization { get; set; } //TODO: add organization to creating challenges

        [Required(ErrorMessage = "Zichtbaarheid moet gedefinieerd worden.")]
        public Visibility ChallengeVisibility { get; set; }
        public int ChallengeVisibility { get; set; }
        public Phase? Phase { get; set; }
    }
}
