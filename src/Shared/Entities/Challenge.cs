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
        public string ShortDescription { get; set; }
        public string BannerImagePath { get; set; }
        public DateTimeOffset Deadline { get; set; }
        public string FinalReport { get; set; }
        public int ChallengeVisibility { get; set; }

        public static IEnumerable<Visibility> Visiblities = new List<Visibility>()
        {
            new() { Id = 0, Name = "" },
            new() { Id = 1, Name = "Zichtbaar alleen voor eigen werknemers" },
            new()
            {
                Id = 2,
                Name = "Zichtbaar alleen voor eigen werknemers en ingelogd gebruikers"
            },
            new() { Id = 3, Name = "Zichtbaar voor iedereen" },
        };
    }

    public class Visibility
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
