namespace MMIP.Shared.Entities
{
    public class Phase : BaseEntity
    {
        public string Name { get; set; } = null!;
        public int Order { get; set; }
        public string Description { get; set; } = null!;
        public List<UserGroup> VisibleTo { get; set; } = new();
    }
}
