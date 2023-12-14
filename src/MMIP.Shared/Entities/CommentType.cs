namespace MMIP.Shared.Entities;

public class CommentType : BaseEntity
{
    public string Name { get; set; } = null!;
    public string IconPath { get; set; } = null!;
    public string Description { get; set; } = null!;
}
