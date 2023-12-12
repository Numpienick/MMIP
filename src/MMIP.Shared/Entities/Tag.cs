using System.ComponentModel.DataAnnotations;

namespace MMIP.Shared.Entities
{
    public class Tag : BaseEntity
    {
        [MaxLength(16, ErrorMessage = "Een tag mag maximaal 16 karakters zijn, verkort deze.")]
        public string? Value { get; set; } = null!;
    }
}
