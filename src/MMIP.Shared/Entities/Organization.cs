namespace MMIP.Shared.Entities
{
    public class Organization : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string EnrollmentCode { get; set; } = null!;
        public Guid SectorId { get; set; }
        public List<Challenge> Challenges { get; set; } = new();
    }
}
