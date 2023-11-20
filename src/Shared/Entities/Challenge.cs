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
        [Required(ErrorMessage = "Challenge titel is vereist.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Omschrijving is vereist.")]
        [StringLength(1000, ErrorMessage = "Maximale omschrijving is 1000 karakters.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Korte omschrijving is vereist.")]
        public string ShortDescription { get; set; }
        public string? BannerImagePath { get; set; }

        [Required(ErrorMessage = "Challenge heeft deadline nodig.")]
        public DateTime? Deadline { get; set; }
        public string? FinalReport { get; set; }

        [Required(ErrorMessage = "Zichtbaarheid moet gedefinieerd worden.")]
        public int ChallengeVisibility { get; set; }
        public static IEnumerable<Visibility> Visiblities = new List<Visibility>()
        {
            Visibility.VisibleForAll(),
            Visibility.VisibleForLoggedin(),
            Visibility.VisibleForEmployees(),
        };
    }
}
