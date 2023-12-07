namespace MMIP.Shared.Entities
{
    public class Branche : BaseEntity
    {
        public string Name { get; set; }
        public Sector Sector { get; set; }
    }
}
