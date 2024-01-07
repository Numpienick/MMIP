namespace MMIP.Shared.Entities
{
    public class Organization : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string EnrollmentCode { get; set; } = null!;
        public Guid SectorId { get; set; }
        public OrganizationProfile Profile { get; set; } = null!;
        public List<Challenge> Challenges { get; set; } = new();
        public List<User> Employees { get; set; } = new();
        public List<Tag> Tags { get; init; } = new();
    }
}
