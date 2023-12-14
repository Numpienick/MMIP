namespace MMIP.Shared.Entities
{
    public interface IProfile
    {
        public List<Tag> Tags { get; set; }
        public string Description { get; set; }
        public string AvatarPath { get; set; }
        public string[] GetTags();
    }
}
