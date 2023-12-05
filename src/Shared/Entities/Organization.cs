namespace Shared.Entities
{
    public class Organization : BaseEntity
    {
        public string Name { get; set; }
        public IEnumerable<Challenge> Challenges { get; set; } = new List<Challenge>();
    }
}
