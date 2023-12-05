namespace Shared.Entities
{
    public class Phase : BaseEntity
    {
        public string Name { get; set; }
        public int Order { get; set; }
        public string Description { get; set; }
        public UserGroup[] VisibleTo { get; set; }
    }
}
