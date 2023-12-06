namespace MMIP.Shared.Entities
{
    public class Text : BaseEntity
    {
        public Text(
            DateTimeOffset createdDate,
            Guid id,
            string languageIso,
            Guid parentId,
            DateTimeOffset updatedDate,
            string value
        )
        {
            CreatedDate = createdDate;
            Id = id;
            LanguageIso = languageIso;
            ParentId = parentId;
            UpdatedDate = updatedDate;
            Value = value;
        }

        public Text() { }

        public string Value { get; set; }
        public Guid ParentId { get; set; }
        public string LanguageIso { get; set; }
    }
}
