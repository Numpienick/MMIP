namespace MMIP.Shared.Entities
{
    public class Organization : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<Challenge> Challenges { get; set; } = new List<Challenge>();
    }
}
