namespace MMIP.Shared.Entities
{
    public class Industry : BaseEntity
    {
        public string Name { get; set; } = null!;
        public Sector Sector { get; set; } = null!;
    }
}
